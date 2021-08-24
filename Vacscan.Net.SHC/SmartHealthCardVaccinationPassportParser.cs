using Jose.keys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vacscan.Net.Core.Models;
using Vacscan.Net.Core.Parsing;
using Vacscan.Net.SHC.JWT;
using Vacscan.Net.SHC.JWT.Models;
using Vacscan.Net.SHC.Models;

namespace Vacscan.Net.SHC
{
    public class SmartHealthCardVaccinationPassportParser : IVaccinationPassportParser
    {
        private readonly static Regex _shcRegex = new Regex(@"(?:shc:/)(?<character>\d{2})+");

        private readonly IEnumerable<ISmartHealthCardJWKProvider> smartHealthCardJWKProviders;

        public SmartHealthCardVaccinationPassportParser(IEnumerable<ISmartHealthCardJWKProvider> smartHealthCardJWKProviders)
        {
            this.smartHealthCardJWKProviders = smartHealthCardJWKProviders;
        }

        public async Task<VaccinationPassportParsingResult> TryParseVaccinationPassportAsync(string vaccinationPassportRaw)
        {
            var result = default(VaccinationPassportParsingResult);
            
            if (_shcRegex.IsMatch(vaccinationPassportRaw) && TryParseRawToJwtSmartHealthCard(vaccinationPassportRaw, out var shc))
            {
                if(await ValidateSmartHealthCardAsync(shc))
                {
                    result = new VaccinationPassportParsingResult { 
                        Raw = vaccinationPassportRaw,
                        VaccinationPassport = ConvertSmartHealthCardToVaccinationPassport(shc.Payload)
                    };
                }
                else
                {
                    result = VaccinationPassportParsingResult.Faulted(new Error { Label = "Fraudulent", Description = "Vaccination passport appears fraudulent" });
                }
            }

            if(result.Raw == null)
            {
                result.Raw = vaccinationPassportRaw;
            }

            return result;
        }

        private bool TryParseRawToJwtSmartHealthCard(string rawSHC, out JWTSmartHealthCard shc)
        {
            shc = SmartHealthCardToJWT(rawSHC);
            return shc != null;
        }

        private JWTSmartHealthCard SmartHealthCardToJWT(string rawSHC)
        {
            var charArray = new List<char>();
            var match = _shcRegex.Match(rawSHC);
            foreach (Capture capture in match.Groups["character"].Captures)
            {
                var characterAsNum = capture.Value;
                var character = (char)(Int32.Parse(characterAsNum, System.Globalization.NumberStyles.Integer) + 45);
                charArray.Add(character);
            }

            var jwt = new String(charArray.ToArray());
            var jwtSplit = jwt.Split('.');

            var rawJwtHeader = jwtSplit[0];
            var rawJwtPayload = jwtSplit[1];
            var rawJwtSignature = jwtSplit[2];

            var jwtHeader = JsonConvert.DeserializeObject<JWTHeader>(Base64UrlDecode(rawJwtHeader));
            jwtHeader.Raw = rawJwtHeader;

            var decompressedRawJwtPayload = rawJwtPayload;
            if (String.Equals(jwtHeader.Zip, "DEF", StringComparison.OrdinalIgnoreCase))
            {
                decompressedRawJwtPayload = DecompressDeflateBase64UrlString(rawJwtPayload);
            }

            var jwtPayload = JsonConvert.DeserializeObject<SmartHealthCard>(decompressedRawJwtPayload);
            jwtPayload.Raw = rawJwtPayload;

            return new JWTSmartHealthCard {
                Header = jwtHeader,
                Payload = jwtPayload,
                Signature = rawJwtSignature,
                Raw = $"{rawJwtHeader}.{rawJwtPayload}.{rawJwtSignature}"
            };
        }

        private async Task<bool> ValidateSmartHealthCardAsync(JWTSmartHealthCard shc)
        {
            foreach(var smartHealthCardJWKProvider in this.smartHealthCardJWKProviders)
            {
                var jwk = await smartHealthCardJWKProvider.TryGetSmartHealthCardJWKAsync(shc);
                if(jwk != null)
                {
                    var eccKeyX = Base64UrlDecodeToBytes(jwk.X);
                    var eccKeyY = Base64UrlDecodeToBytes(jwk.Y);

                    var publicKey = EccKey.New(eccKeyX, eccKeyY);

                    try
                    {
                        Jose.JWT.Decode(shc.Raw, publicKey);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        private string DecompressDeflateBase64UrlString(string input, Encoding encoding = default(Encoding))
        {
            encoding = encoding ?? Encoding.UTF8;

            var inputBytes = Base64UrlDecodeToBytes(input);

            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(inputBytes))
                using (var decompressionStream = new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(outputStream);
                }

                var outputBytes = outputStream.ToArray();
                return encoding.GetString(outputBytes);
            }
        }

        private string Base64UrlDecode(string value, Encoding encoding = default(Encoding))
        {
            encoding = encoding ?? Encoding.UTF8;

            byte[] bytes = Base64UrlDecodeToBytes(value);
            return encoding.GetString(bytes);
        }

        private byte[] Base64UrlDecodeToBytes(string value)
        {
            string incoming = value
                .Replace('_', '/')
                .Replace('-', '+');

            switch (value.Length % 4)
            {
                case 2: incoming += "=="; break;
                case 3: incoming += "="; break;
            }

            return Convert.FromBase64String(incoming);
        }

        private SmartHealthCardVaccinationPassport ConvertSmartHealthCardToVaccinationPassport(SmartHealthCard smartHealthCard)
        {
            var result = new SmartHealthCardVaccinationPassport { 
                SmartHealthCard = smartHealthCard
            };

            var patient = smartHealthCard.Vc.CredentialSubject.FhirBundle.Entry.FirstOrDefault((e) => e.Resource.ResourceType == "Patient");
            if(patient != null)
            {
                result.Person = new Person { 
                    DateOfBirth = DateTime.TryParse(patient.Resource.BirthDate, out var dob) ? dob : default(DateTime),
                    FirstName = String.Join(" ", patient.Resource.Name.FirstOrDefault()?.Given),
                    LastName = String.Join(" ", patient.Resource.Name.FirstOrDefault()?.Family)
                };
            }

            if(String.Equals(smartHealthCard.Iss.Authority, "covid19.quebec.ca", StringComparison.OrdinalIgnoreCase))
            {
                result.Issuer = Issuer.CanadaQuebec;
            }

            var injections = smartHealthCard.Vc.CredentialSubject.FhirBundle.Entry.Where((e) => e.Resource.ResourceType == "Immunization").ToList();
            foreach(var injection in injections)
            {
                var vaccine = default(Vaccine);

                if (String.Equals(injection.Resource.VaccineCode.Coding[0].Code, SmartHealthCardVaccine.SmartHealthCardCovid19Pfizer.CvxCode))
                {
                    vaccine = SmartHealthCardVaccine.SmartHealthCardCovid19Pfizer;
                }
                else if (String.Equals(injection.Resource.VaccineCode.Coding[0].Code, SmartHealthCardVaccine.SmartHealthCardCovid19Moderna.CvxCode))
                {
                    vaccine = SmartHealthCardVaccine.SmartHealthCardCovid19Moderna;
                }
                else if (String.Equals(injection.Resource.VaccineCode.Coding[0].Code, SmartHealthCardVaccine.SmartHealthCardCovid19Astrazeneca.CvxCode))
                {
                    vaccine = SmartHealthCardVaccine.SmartHealthCardCovid19Astrazeneca;
                }

                result.Items.Add(new SmartHealthCardVaccineInjection
                { 
                    Description = $"{injection.Resource.Note[0].Text} dose #{injection.Resource.ProtocolApplied.DoseNumber}",
                    Timestamp = injection.Resource.OccurrenceDateTime,
                    Vaccine = vaccine,
                    SmartHealthCardEntry = injection
                });
            }

            return result;
        }
    }
}
