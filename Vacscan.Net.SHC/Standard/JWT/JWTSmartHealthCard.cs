using Vacscan.Net.SHC.Standard;

namespace Vacscan.Net.SHC.Standard.JWT
{
    public class JWTSmartHealthCard
    {
        public JWTHeader Header {  get; set; }

        public SmartHealthCard Payload { get; set; }

        public string Signature { get; set; }

        public string Raw { get; set; }
    }
}
