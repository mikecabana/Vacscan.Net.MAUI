using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vacscan.Net.Core.Immunization.Issuance
{
    public class IssuerProvider : IIssuerProvider
    {
        private readonly IEnumerable<IIssuerProvider> issuerProviders;

        public IssuerProvider(IEnumerable<IIssuerProvider> issuerProviders)
        {
            this.issuerProviders = issuerProviders;
        }

        public async Task<IEnumerable<Issuer>> GetIssuersAsync()
        {
            var issuers = new List<Issuer>();

            foreach (var issuerProvider in issuerProviders)
            {
                var providedIssuers = await issuerProvider.GetIssuersAsync();
                issuers.AddRange(providedIssuers);
            }

            return issuers;
        }
    }
}
