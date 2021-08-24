using System.Threading.Tasks;
using Vacscan.Net.SHC.JWT.Models;

namespace Vacscan.Net.SHC.JWT
{
    public abstract class BaseSmartHealthCardJWKProvider : ISmartHealthCardJWKProvider
    {
        public virtual int Order => 0;

        protected BaseSmartHealthCardJWKProvider()
        {

        }

        public abstract Task<JWK> TryGetSmartHealthCardJWKAsync(JWTSmartHealthCard shc);
    }
}
