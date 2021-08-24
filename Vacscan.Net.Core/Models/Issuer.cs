namespace Vacscan.Net.Core.Models
{
    public class Issuer
    {
        public static readonly Issuer CanadaQuebec = new Issuer("ca.qc.gov", "Canada/Quebec");

        public static readonly Issuer CanadaOntario = new Issuer("ca.on.gov", "Canada/Ontario");

        public static readonly Issuer France = new Issuer("fr.gov", "France");

        public static readonly Issuer EuropeanUnion = new Issuer("eu.gov", "European Union");

        public Issuer() { }

        public Issuer(string key, string label)
        {
            Key = key;
            Label = label;
        }

        public string Key { get; set; }

        public string Label { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Vaccine v && v.Key == Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
