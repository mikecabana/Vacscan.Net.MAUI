using System.Collections.Generic;

namespace Vacscan.Net.SHC.Immunization.Issuance.Internal
{
    public class SmartHealthCardVaccineConfiguration
    {
        public static readonly object IssuerPropertyKey = typeof(SmartHealthCardVaccineConfiguration);

        public List<string> CvxCodes { get; } = new List<string>();

        public SmartHealthCardVaccineConfiguration AddCvxCode(string code)
        {
            CvxCodes.Add(code);
            return this;
        }

        public SmartHealthCardVaccineConfiguration AddCvxCode(int code)
        {
            return AddCvxCode(code.ToString());
        }
    }
}
