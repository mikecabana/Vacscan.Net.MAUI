using System;
using System.Linq;
using System.Threading.Tasks;
using Vacscan.Net.Core.Immunization.Vaccination;
using Vacscan.Net.SHC.Immunization.Issuance.Internal;
using Vacscan.Net.SHC.Standard;

namespace Vacscan.Net.SHC.Immunization.Vaccination
{
    public class SmartHealthCardEntryVaccineResolver
    {
        private readonly VaccineProvider vaccineProvider;

        public SmartHealthCardEntryVaccineResolver(VaccineProvider vaccineProvider)
        {
            this.vaccineProvider = vaccineProvider;
        }

        public async Task<Vaccine> ResolveVaccineAsync(SmartHealthCardEntry smartHealthCardEntry, SmartHealthCard smartHealthCard)
        {
            var shcCvxCode = smartHealthCardEntry.Resource.VaccineCode.Coding.First().Code;

            var vaccines = await this.vaccineProvider.GetVaccinesAsync();
            foreach(var vaccine in vaccines)
            {
                var configuration = vaccine.GetProperty<SmartHealthCardVaccineConfiguration>(SmartHealthCardVaccineConfiguration.IssuerPropertyKey);
                if (configuration != null)
                {
                    foreach (var vaccineCvxCode in configuration.CvxCodes)
                    {
                        if (String.Equals(vaccineCvxCode, shcCvxCode, StringComparison.OrdinalIgnoreCase))
                        {
                            return vaccine;
                        }
                    }
                }
            }

            return null;
        }
    }
}
