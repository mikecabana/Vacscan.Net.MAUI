using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacscan.Net.Core.Immunization.Identity;
using Vacscan.Net.Core.Immunization.Issuance;
using Vacscan.Net.Core.Immunization.Vaccination;
using Vacscan.Net.Core.Miscellaneous;
using Vacscan.Net.Core.Parsing;
using Vacscan.Net.SHC.Immunization;
using Vacscan.Net.SHC.Immunization.Issuance;
using Vacscan.Net.SHC.Immunization.Vaccination;
using Vacscan.Net.SHC.Standard;
using Vacscan.Net.SHC.Standard.JWT;

namespace Vacscan.Net.SHC
{
    public class SmartHealthCardImmunizationPassportParser : IImmunizationPassportParser
    {
        private readonly JWTSmartHealthCardParser jWTSmartHealthCardParser;
        
        private readonly JWTSmartHealthCardValidator jWTSmartHealthCardValidator;

        private readonly SmartHealthCardIssuerResolver smartHealthCardIssuerResolver;

        private readonly SmartHealthCardEntryVaccineResolver smartHealthCardEntryVaccineResolver;

        public SmartHealthCardImmunizationPassportParser(
            JWTSmartHealthCardParser jWTSmartHealthCardParser, 
            JWTSmartHealthCardValidator jWTSmartHealthCardValidator,
            SmartHealthCardIssuerResolver smartHealthCardIssuerResolver,
            SmartHealthCardEntryVaccineResolver smartHealthCardEntryVaccineResolver,
            IEnumerable<IVaccineProvider> vaccineProviders, 
            IEnumerable<IIssuerProvider> issuerProviders)
        {
            this.jWTSmartHealthCardParser = jWTSmartHealthCardParser;
            this.jWTSmartHealthCardValidator = jWTSmartHealthCardValidator;
            this.smartHealthCardIssuerResolver = smartHealthCardIssuerResolver;
            this.smartHealthCardEntryVaccineResolver = smartHealthCardEntryVaccineResolver;
        }

        public async Task<ImmunizationPassportParsingResult> TryParseImmunizationPassportAsync(string vaccinationPassportRaw)
        {
            var result = default(ImmunizationPassportParsingResult);
            
            if (jWTSmartHealthCardParser.RawImmunizationPassportIsSmartHealthCard(vaccinationPassportRaw))
            {
                var shc = jWTSmartHealthCardParser.ConvertRawSmartHealthCardToJWT(vaccinationPassportRaw);

                var immunizationPassport = await ConvertSmartHealthCardToVaccinationPassportAsync(shc.Payload);

                var isValid = await jWTSmartHealthCardValidator.ValidateSmartHealthCardAsync(shc);

                if(isValid == null)
                {
                    var warning = new Error {
                        Label = "Might be Fraudulent",
                        Description = "Could not be validated"
                    };

                    result = ImmunizationPassportParsingResult.Success(immunizationPassport, warning);
                }
                else if (isValid.Value)
                {
                    result = ImmunizationPassportParsingResult.Success(immunizationPassport);
                }
                else
                {
                    result = ImmunizationPassportParsingResult.Faulted(new Error { Label = "Fraudulent", Description = "Vaccination passport appears fraudulent" });
                }
            }

            if(result.Raw == null)
            {
                result.Raw = vaccinationPassportRaw;
            }

            return result;
        }

        private async Task<SmartHealthCardImmunizationPassport> ConvertSmartHealthCardToVaccinationPassportAsync(SmartHealthCard smartHealthCard)
        {
            var result = new SmartHealthCardImmunizationPassport { 
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

            result.Issuer = await this.smartHealthCardIssuerResolver.ResolveIssuerAsync(smartHealthCard);

            var injections = smartHealthCard.Vc.CredentialSubject.FhirBundle.Entry.Where((e) => e.Resource.ResourceType == "Immunization").ToList();
            foreach(var injection in injections)
            {
                var vaccine = await this.smartHealthCardEntryVaccineResolver.ResolveVaccineAsync(injection, smartHealthCard);

                result.Items.Add(new SmartHealthCardVaccineInjection
                { 
                    Description = $"{injection.Resource.Note.First().Text} dose #{injection.Resource.ProtocolApplied.DoseNumber}",
                    Timestamp = injection.Resource.OccurrenceDateTime,
                    Vaccine = vaccine,
                    SmartHealthCardEntry = injection
                });
            }

            return result;
        }
    }
}
