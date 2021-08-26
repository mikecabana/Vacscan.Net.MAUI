namespace Vacscan.Net.SHC.Standard.JWT
{
    public class JWK
    {
        public string Kid { get; set; }

        public string Kty { get; set; }
        
        public string Use { get; set; }
        
        public string Alg { get; set; }
        
        public string Crv { get; set; }
        
        public string X { get; set; }
        
        public string Y { get; set; }
    }
}
