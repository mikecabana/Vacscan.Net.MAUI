using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Vacscan.Net.SHC.Standard.JWT
{
    public class HttpJWTSmartHealthCardJWKProvider : BaseJWTSmartHealthCardJWKProvider
    {
        public override int Order => Int32.MaxValue;

        private readonly HttpClient httpClient;

        public HttpJWTSmartHealthCardJWKProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public override async Task<JWK> TryGetSmartHealthCardJWKAsync(JWTSmartHealthCard shc)
        {
            var jwkUri = new Uri(shc.Payload.Iss, ".well-known/jwks.json");
            var jwkJsonData = await httpClient.GetStringAsync(jwkUri);

            var jwks = JsonConvert.DeserializeAnonymousType(jwkJsonData, new
            {
                keys = default(JWK[])
            });

            return jwks.keys.FirstOrDefault((k) => k.Kid == shc.Header.Kid);
        }
    }
}
