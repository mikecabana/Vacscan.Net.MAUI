using Vacscan.Net.Core.Internal;

namespace Vacscan.Net.Core.Immunization.Issuance
{
    public class Issuer : KeyAtomicObjectWithProperties
    {
        public static readonly Issuer CanadaQuebec = new Issuer("ca.qc.gov", "Canada/Quebec");

        public static readonly Issuer EuropeanUnion = new Issuer("eu.gov", "European Union");

        public Issuer()
            : base() { }

        public Issuer(string key, string label)
            : base(key)
        {
            Label = label;
        }

        public Issuer(Issuer isser)
            : this(isser.Key, isser.Label) { }

        public string Label { get; set; }
    }
}
