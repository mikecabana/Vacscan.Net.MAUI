using System.Threading.Tasks;
using Vacscan.Net.SHC.JWT.Models;

namespace Vacscan.Net.SHC.JWT
{
    public interface ISmartHealthCardJWKProvider
    {
        int Order { get; }

        Task<JWK> TryGetSmartHealthCardJWKAsync(JWTSmartHealthCard shc);
    }
}
