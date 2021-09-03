using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vacscan.Net.XAMARIN.Models.Configs;
using Vacscan.Net.XAMARIN.Models.Configs.RegionConfigs;
using Vacscan.Net.XAMARIN.Models.RegionConfigs;

namespace Vacscan.Net.XAMARIN.ViewModels
{
    public class PreferencesViewModel : BaseViewModel
    {
        public string SelectedCountryName { get; set; }

        public string SelectedRegionName { get; set; }

        public IList<IImmunizationCountryConfig> CountryConfigs { get; set; }

        public IImmunizationCountryConfig SelectedImmunizationCountryConfig { get; set; }

        public string[] AvailableCountries => CountryConfigs.Select(c => c.Name).ToArray();

        public string[] AvailableRegions { get; set; }

        public PreferencesViewModel()
        {
            Title = "Settings";
            CountryConfigs = new List<IImmunizationCountryConfig>()
            {
                new CanadaImmunizationCountryConfig()
            };
        }


        public void OnCountryChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Country selected {SelectedCountryName}");


            if (!string.IsNullOrWhiteSpace(SelectedCountryName))
            {
                AvailableRegions = CountryConfigs
                    .Where(c => c.Name == SelectedCountryName)
                    .Select(c => c.Regions)
                    .ToArray()
                    .First();
            }
        }

        public void OnRegionChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Region selected {SelectedRegionName}");
        }

    }
}
