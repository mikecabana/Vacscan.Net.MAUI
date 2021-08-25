using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacscan.Net.Core.Immunization.Vaccination;
using Vacscan.Net.Core.Internal.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public class VaccineServiceRegistration : SingletonInstanceServiceRegistration<Vaccine>, IVaccineProvider
    {
        public VaccineServiceRegistration(IServiceCollection services, Vaccine vaccine)
            : base(services, vaccine) { }

        public Task<IEnumerable<Vaccine>> GetVaccinesAsync()
        {
            var result = new[] { Instance };
            return Task.FromResult<IEnumerable<Vaccine>>(result);
        }
    }
}
