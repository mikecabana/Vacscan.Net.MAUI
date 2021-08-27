using System;
using System.Collections.Generic;
using System.Text;
using Vacscan.Net.XAMARIN.Models.Configs.RegionConfigs;
using Vacscan.Net.XAMARIN.Models.RegionConfigs;

namespace Vacscan.Net.XAMARIN.Models.Configs
{
    public class CanadaImmunizationCountryConfig : IImmunizationCountryConfig
    {
        public Countries Type
        {
            get => Countries.CANADA;
        }

        public string Name
        {
            get => "Canada";
        }

        public string[] Regions
        {
            get
            {
                return new string[] {
                    "Quebec"
                };
            }
        }

        public Dictionary<string, IImmunizationRegionConfig> RegionConfigs
        {
            get
            {
                var dict = new Dictionary<string, IImmunizationRegionConfig>();
                dict
                    .Add("Quebec", new QuebecImmunizationConfig());
                return dict;
            }
        }
    }
}
