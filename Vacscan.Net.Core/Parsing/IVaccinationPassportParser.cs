using System.Threading.Tasks;
using Vacscan.Net.Core.Models;

namespace Vacscan.Net.Core.Parsing
{
    public interface IVaccinationPassportParser
    {
        Task<VaccinationPassportParsingResult> TryParseVaccinationPassportAsync(string vaccinationPassportRaw);
    }
}
