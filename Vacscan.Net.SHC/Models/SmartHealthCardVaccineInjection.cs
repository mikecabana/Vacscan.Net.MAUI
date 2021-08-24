using System;
using System.Collections.Generic;
using System.Text;
using Vacscan.Net.Core.Models;

namespace Vacscan.Net.SHC.Models
{
    public class SmartHealthCardVaccineInjection : VaccineInjection
    {
        public Entry SmartHealthCardEntry { get; set; }
    }
}
