namespace Vacscan.Net.Core.Models
{
    public class Vaccine
    {
        public static readonly Vaccine Covid19Pfizer = new Vaccine("covid19.pfizer", "Pfizer");

        public static readonly Vaccine Covid19Moderna = new Vaccine("covid19.moderna", "Moderna");

        public static readonly Vaccine Covid19Astrazeneca = new Vaccine("covid19.astrazeneca", "Astrazeneca");

        public Vaccine() { }

        public Vaccine(string key, string label)
        {
            Key = key;
            Label = label;
        }

        public Vaccine(Vaccine vaccine)
            : this(vaccine.Key, vaccine.Label) { }

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
