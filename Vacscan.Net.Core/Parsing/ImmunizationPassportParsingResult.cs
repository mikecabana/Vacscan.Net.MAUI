using Vacscan.Net.Core.Immunization;
using Vacscan.Net.Core.Miscellaneous;

namespace Vacscan.Net.Core.Parsing
{
    public class ImmunizationPassportParsingResult
    {
        public static ImmunizationPassportParsingResult Success(ImmunizationPassport immunizationPassport)
        {
            return new ImmunizationPassportParsingResult
            {
                ImmunizationPassport = immunizationPassport
            };
        }

        public static ImmunizationPassportParsingResult Faulted(Error error)
        {
            return new ImmunizationPassportParsingResult
            {
                Error = error
            };
        }


        public static ImmunizationPassportParsingResult NotRecognized()
        {
            return null;
        }

        public string Raw { get; set; }

        public ImmunizationPassport ImmunizationPassport { get; set; }

        public Error Error { get; set; }

        public bool HasError => Error != null;

        public bool IsSuccess => !HasError && ImmunizationPassport != null;
    }
}
