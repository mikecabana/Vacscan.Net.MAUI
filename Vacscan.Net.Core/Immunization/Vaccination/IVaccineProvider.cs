using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vacscan.Net.Core.Immunization.Vaccination
{
    public interface IVaccineProvider
    {
        Task<IEnumerable<Vaccine>> GetVaccinesAsync();
    }
}
