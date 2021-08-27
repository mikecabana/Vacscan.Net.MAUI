using System;
using System.Collections.Generic;
using System.Text;
using Vacscan.Net.XAMARIN.Models.RegionConfigs;

namespace Vacscan.Net.XAMARIN.Models.Configs.RegionConfigs
{
    public class QuebecImmunizationConfig : IImmunizationRegionConfig
    {
        public string Authority => "covid19.quebec.ca";
    }
}
