using System.Collections.Generic;
using Vacscan.Net.Core.Immunization.Identity;
using Vacscan.Net.Core.Immunization.Issuance;
using Vacscan.Net.Core.Immunization.Vaccination;

namespace Vacscan.Net.Core.Immunization
{
    public class ImmunizationPassport
    {
        public Issuer Issuer { get; set; }

        public Person Person { get; set; }

        public ICollection<VaccineInjection> Items { get; } = new List<VaccineInjection>();
    }
}
