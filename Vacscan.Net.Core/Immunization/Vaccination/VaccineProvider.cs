using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vacscan.Net.Core.Immunization.Vaccination
{
    public class VaccineProvider : IVaccineProvider
    {
        private readonly IEnumerable<IVaccineProvider> vaccineProviders;

        public VaccineProvider(IEnumerable<IVaccineProvider> vaccineProviders)
        {
            this.vaccineProviders = vaccineProviders;
        }

        public async Task<IEnumerable<Vaccine>> GetVaccinesAsync()
        {
            var vaccines = new List<Vaccine>();

            foreach(var vaccineProvider in vaccineProviders)
            {
                var providedVaccines = await vaccineProvider.GetVaccinesAsync();
                vaccines.AddRange(providedVaccines);
            }

            return vaccines;
        }
    }
}
