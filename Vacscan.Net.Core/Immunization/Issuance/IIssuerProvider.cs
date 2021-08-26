using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vacscan.Net.Core.Immunization.Issuance
{
    public interface IIssuerProvider
    {
        Task<IEnumerable<Issuer>> GetIssuersAsync();
    }
}
