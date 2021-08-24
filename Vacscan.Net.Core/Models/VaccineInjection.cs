using System;
using System.Collections.Generic;
using System.Text;

namespace Vacscan.Net.Core.Models
{
    public class VaccineInjection : VaccinationPassportItem
    {
        public VaccineInjection()
            : base(VaccinationPassportItemType.VaccineInjection) { }

        public Vaccine Vaccine { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} ({Vaccine})";
        }
    }
}
