using System.Threading.Tasks;
using Vacscan.Net.Core.Immunization.Issuance;
using Vacscan.Net.SHC.Immunization.Issuance.Internal;

namespace Vacscan.Net.SHC.Standard.JWT
{
    public class IssuersJWTSmartHealthCardJWKProvider : BaseJWTSmartHealthCardJWKProvider
    {
        private readonly IssuerProvider issuerProvider;

        public IssuersJWTSmartHealthCardJWKProvider(IssuerProvider issuerProvider)
        {
            this.issuerProvider = issuerProvider;
        }

        public override async Task<JWK> TryGetSmartHealthCardJWKAsync(JWTSmartHealthCard shc)
        {
            var kid = shc.Header.Kid;
            var issuers = await issuerProvider.GetIssuersAsync();
            foreach(var issuer in issuers)
            {
                var configuration = issuer.GetProperty<SmartHealthCardIssuerConfiguration>(SmartHealthCardIssuerConfiguration.IssuerPropertyKey);
                if(configuration != null)
                {
                    foreach(var jwk in configuration.JWKs)
                    {
                        if (jwk.Kid == kid)
                        {
                            return jwk;
                        }
                    }
                }
            }

            return null;
        }
    }
}
