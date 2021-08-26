using System;
using System.Threading.Tasks;
using Vacscan.Net.Core.Immunization.Issuance;
using Vacscan.Net.SHC.Immunization.Issuance.Internal;
using Vacscan.Net.SHC.Standard;

namespace Vacscan.Net.SHC.Immunization.Issuance
{
    public class SmartHealthCardIssuerResolver
    {
        private readonly IssuerProvider issuerProvider;

        public SmartHealthCardIssuerResolver(IssuerProvider issuerProvider)
        {
            this.issuerProvider = issuerProvider;
        }

        public async Task<Issuer> ResolveIssuerAsync(SmartHealthCard smartHealthCard)
        {
            var shcIssuerAuthority = smartHealthCard.Iss.Authority;

            var issuers = await issuerProvider.GetIssuersAsync();
            foreach(var issuer in issuers)
            {
                var configuration = issuer.GetProperty<SmartHealthCardIssuerConfiguration>(SmartHealthCardIssuerConfiguration.IssuerPropertyKey);
                if(configuration != null)
                {
                    foreach(var issuerAuthority in configuration.IssuerAuthorities)
                    {
                        if(String.Equals(issuerAuthority, shcIssuerAuthority, StringComparison.OrdinalIgnoreCase))
                        {
                            return issuer;
                        }
                    }
                }
            }

            return null;
        }
    }
}
