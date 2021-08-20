namespace Vacscan.Net.SHC.JWT.Models
{
    public class JWTHeader
    {
        public string Kid { get; set; }

        public string Zip { get; set; }

        public string Alg { get; set; }

        public string Raw { get; set; }
    }
}
