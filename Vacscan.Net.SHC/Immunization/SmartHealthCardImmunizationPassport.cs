using Vacscan.Net.Core.Immunization;
using Vacscan.Net.SHC.Standard;

namespace Vacscan.Net.SHC.Immunization
{
    public class SmartHealthCardImmunizationPassport : ImmunizationPassport
    {
        public SmartHealthCard SmartHealthCard { get; set; }
    }
}
