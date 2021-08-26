using System.Threading.Tasks;

namespace Vacscan.Net.Core.Parsing
{
    public interface IImmunizationPassportParser
    {
        Task<ImmunizationPassportParsingResult> TryParseImmunizationPassportAsync(string immunizationPassportRaw);
    }
}
