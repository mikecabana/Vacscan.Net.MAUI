using Vacscan.Net.Core.Models;

namespace Vacscan.Net.SHC.Models
{
    public class SmartHealthCardVaccine : Vaccine
    {
        // https://www2a.cdc.gov/vaccines/iis/iisstandards/vaccines.asp?rpt=cvx
        public static readonly SmartHealthCardVaccine SmartHealthCardCovid19Pfizer = new SmartHealthCardVaccine(Vaccine.Covid19Pfizer, "208");

        public static readonly SmartHealthCardVaccine SmartHealthCardCovid19Moderna = new SmartHealthCardVaccine(Vaccine.Covid19Moderna, "207");

        public static readonly SmartHealthCardVaccine SmartHealthCardCovid19Astrazeneca = new SmartHealthCardVaccine(Vaccine.Covid19Astrazeneca, "210");

        public string CvxCode { get; set; }

        public SmartHealthCardVaccine()
        {

        }

        public SmartHealthCardVaccine(Vaccine vaccine, string cvxCode)
            : base(vaccine) 
        { 
            CvxCode = cvxCode;  
        }
    }
}
