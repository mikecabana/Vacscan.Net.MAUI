using System.Threading.Tasks;
using Vacscan.Net.SHC.JWT.Models;

namespace Vacscan.Net.SHC.JWT
{
    public class StaticSmartHealthCardJWKProvider : BaseSmartHealthCardJWKProvider
    {
        private readonly JWK jWK;

        public StaticSmartHealthCardJWKProvider(JWK jWK)
        {
            this.jWK = jWK;
        }

        public override Task<JWK> TryGetSmartHealthCardJWKAsync(JWTSmartHealthCard shc)
        {
            var result = default(JWK);
            if(shc.Header.Kid == this.jWK.Kid)
            {
                result = this.jWK;
            }

            return Task.FromResult(result);
        }
    }
}
