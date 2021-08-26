using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacscan.Net.Core.Immunization.Issuance;
using Vacscan.Net.Core.Internal.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public class IssuerServiceRegistration : SingletonInstanceServiceRegistration<Issuer>, IIssuerProvider
    {
        public IssuerServiceRegistration(IServiceCollection services, Issuer issuer)
            : base(services, issuer) { }

        public Task<IEnumerable<Issuer>> GetIssuersAsync()
        {
            var result = new[] { Instance };
            return Task.FromResult<IEnumerable<Issuer>>(result);
        }
    }
}
