using Vacscan.Net.SHC.Models;

namespace Vacscan.Net.SHC.JWT.Models
{
    public class JWTSmartHealthCard
    {
        public JWTHeader Header {  get; set; }

        public SmartHealthCard Payload { get; set; }

        public string Signature { get; set; }

        public string Raw { get; set; }
    }
}
