using Vacscan.Net.Core.Models;

namespace Vacscan.Net.Core.Parsing
{
    public class VaccinationPassportParsingResult
    {
        public static VaccinationPassportParsingResult Success(VaccinationPassport vaccinationPassport)
        {
            return new VaccinationPassportParsingResult
            {
                VaccinationPassport = vaccinationPassport
            };
        }

        public static VaccinationPassportParsingResult Faulted(Error error)
        {
            return new VaccinationPassportParsingResult
            {
                Error = error
            };
        }


        public static VaccinationPassportParsingResult NotRecognized()
        {
            return null;
        }

        public string Raw { get; set; }

        public VaccinationPassport VaccinationPassport { get; set; }

        public Error Error { get; set; }

        public bool HasError => Error != null;

        public bool IsSuccess => !HasError && VaccinationPassport != null;
    }
}
