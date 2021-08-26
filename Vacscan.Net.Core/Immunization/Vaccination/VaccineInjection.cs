namespace Vacscan.Net.Core.Immunization.Vaccination
{
    public class VaccineInjection : ImmunizationPassportItem
    {
        public VaccineInjection()
            : base(ImmunizationPassportItemType.VaccineInjection) { }

        public Vaccine Vaccine { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} ({Vaccine})";
        }
    }
}
