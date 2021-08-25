using System.Threading.Tasks;

namespace Vacscan.Net.SHC.Standard.JWT
{
    public interface IJWTSmartHealthCardJWKProvider
    {
        int Order { get; }

        Task<JWK> TryGetSmartHealthCardJWKAsync(JWTSmartHealthCard shc);
    }
}
