using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace Vacscan.Net.SHC.Standard.JWT
{
    public class JWTSmartHealthCardParser
    {
        private readonly static Regex _shcRegex = new Regex(@"(?:shc:/)(?<character>\d{2})+");

        public bool RawImmunizationPassportIsSmartHealthCard(string rawImmunizationPassport)
        {
            return _shcRegex.IsMatch(rawImmunizationPassport);
        }

        public JWTSmartHealthCard ConvertRawSmartHealthCardToJWT(string rawSHC)
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

            var jwtHeader = JsonConvert.DeserializeObject<JWTHeader>(rawJwtHeader.Base64UrlDecode());
            jwtHeader.Raw = rawJwtHeader;

            var decompressedRawJwtPayload = rawJwtPayload;
            if (String.Equals(jwtHeader.Zip, "DEF", StringComparison.OrdinalIgnoreCase))
            {
                decompressedRawJwtPayload = DecompressDeflateBase64UrlString(rawJwtPayload);
            }

            var jwtPayload = JsonConvert.DeserializeObject<SmartHealthCard>(decompressedRawJwtPayload);
            jwtPayload.Raw = rawJwtPayload;

            return new JWTSmartHealthCard
            {
                Header = jwtHeader,
                Payload = jwtPayload,
                Signature = rawJwtSignature,
                Raw = $"{rawJwtHeader}.{rawJwtPayload}.{rawJwtSignature}"
            };
        }

        private string DecompressDeflateBase64UrlString(string input, Encoding encoding = default(Encoding))
        {
            encoding = encoding ?? Encoding.UTF8;

            var inputBytes = input.Base64UrlDecodeToBytes();

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
    }
}
