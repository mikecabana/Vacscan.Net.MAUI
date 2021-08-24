using System.Collections.Generic;

namespace Vacscan.Net.Core.Models
{
    public class VaccinationPassport
    {
        public Issuer Issuer { get; set; }

        public Person Person { get; set; }

        public ICollection<VaccineInjection> Items { get; } = new List<VaccineInjection>();
    }
}
