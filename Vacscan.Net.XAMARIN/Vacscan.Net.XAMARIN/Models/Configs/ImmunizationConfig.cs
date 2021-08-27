using System.Collections.Generic;

namespace Vacscan.Net.XAMARIN.Models.Configs
{
    public class ImmunizationConfig
    {
        public Dictionary<Countries, IImmunizationCountryConfig> Configs
        {
            get => new Dictionary<Countries, IImmunizationCountryConfig>
            {
                { Countries.CANADA, new CanadaImmunizationCountryConfig() }
            };

        }
    }
}
