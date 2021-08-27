using System;
using System.Collections.Generic;
using System.Text;
using Vacscan.Net.XAMARIN.Models.RegionConfigs;

namespace Vacscan.Net.XAMARIN.Models.Configs
{
    public interface IImmunizationCountryConfig
    {
        Countries Type {  get; }

        string Name { get; }

        string[] Regions { get; }

        Dictionary<string, IImmunizationRegionConfig> RegionConfigs { get; }
    }
}
