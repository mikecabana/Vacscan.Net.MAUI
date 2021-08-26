using Vacscan.Net.Core.Internal;

namespace Vacscan.Net.Core.Immunization.Vaccination
{
    public class Vaccine : KeyAtomicObjectWithProperties
    {
        public static readonly Vaccine Covid19Pfizer = new Vaccine("covid19.pfizer", "Pfizer");

        public static readonly Vaccine Covid19Moderna = new Vaccine("covid19.moderna", "Moderna");

        public static readonly Vaccine Covid19Astrazeneca = new Vaccine("covid19.astrazeneca", "Astrazeneca");

        public Vaccine()
            : base() { }

        public Vaccine(string key, string label)
            : base(key)
        {
            Label = label;
        }

        public Vaccine(Vaccine vaccine)
            : this(vaccine.Key, vaccine.Label) { }

        public string Label { get; set; }
    }
}
