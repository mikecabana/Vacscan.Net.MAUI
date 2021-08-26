using System.Collections.Generic;
using System.Threading.Tasks;
using Vacscan.Net.Core.Miscellaneous;

namespace Vacscan.Net.Core.Parsing
{
    public class ImmunizationPassportParser : IImmunizationPassportParser
    {
        private readonly IEnumerable<IImmunizationPassportParser> immunizationPassportParsers;

        public ImmunizationPassportParser(IEnumerable<IImmunizationPassportParser> immunizationPassportParsers)
        {
            this.immunizationPassportParsers = immunizationPassportParsers;
        }

        public async Task<ImmunizationPassportParsingResult> TryParseImmunizationPassportAsync(string immunizationPassportRaw)
        {
            ImmunizationPassportParsingResult result = null;
            
            foreach (var immunizationPassportParser in immunizationPassportParsers)
            {
                result = await immunizationPassportParser.TryParseImmunizationPassportAsync(immunizationPassportRaw);
                if (result?.IsSuccess == true)
                {
                    break;
                }
            }

            if(result == null)
            {
                result = ImmunizationPassportParsingResult.Faulted(new Error { 
                    Label = "No Matches",
                    Description = "System could not parse provided value"
                });
            }    

            if(result.Raw == null)
            {
                result.Raw = immunizationPassportRaw;
            }

            return result;
        }
    }
}
