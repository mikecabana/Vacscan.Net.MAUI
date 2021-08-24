using Vacscan.Net.Core.Models;
using Vacscan.Net.Core.Parsing;

namespace Vacscan.Net.SHC.Models
{
    public class SmartHealthCardVaccinationPassport : VaccinationPassport
    {
        public SmartHealthCard SmartHealthCard { get; set; }
    }
}
