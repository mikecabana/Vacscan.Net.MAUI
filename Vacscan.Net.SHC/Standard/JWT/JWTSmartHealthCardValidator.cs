using Jose.keys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vacscan.Net.SHC.Standard.JWT
{
    public class JWTSmartHealthCardValidator
    {
        private readonly IEnumerable<IJWTSmartHealthCardJWKProvider> jwtSmartHealthCardJWKProviders;

        public JWTSmartHealthCardValidator(IEnumerable<IJWTSmartHealthCardJWKProvider> jwtSmartHealthCardJWKProviders)
        {
            this.jwtSmartHealthCardJWKProviders = jwtSmartHealthCardJWKProviders;
        }

        public async Task<bool?> ValidateSmartHealthCardAsync(JWTSmartHealthCard shc)
        {
            foreach (var smartHealthCardJWKProvider in this.jwtSmartHealthCardJWKProviders)
            {
                var jwk = await smartHealthCardJWKProvider.TryGetSmartHealthCardJWKAsync(shc);
                if (jwk != null)
                {
                    var eccKeyX = jwk.X.Base64UrlDecodeToBytes();
                    var eccKeyY = jwk.Y.Base64UrlDecodeToBytes();

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

            return null;
        }
    }
}
