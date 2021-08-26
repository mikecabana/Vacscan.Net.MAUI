using System.Threading.Tasks;

namespace Vacscan.Net.SHC.Standard.JWT
{
    public abstract class BaseJWTSmartHealthCardJWKProvider : IJWTSmartHealthCardJWKProvider
    {
        public virtual int Order => 0;

        protected BaseJWTSmartHealthCardJWKProvider()
        {

        }

        public abstract Task<JWK> TryGetSmartHealthCardJWKAsync(JWTSmartHealthCard shc);
    }
}
