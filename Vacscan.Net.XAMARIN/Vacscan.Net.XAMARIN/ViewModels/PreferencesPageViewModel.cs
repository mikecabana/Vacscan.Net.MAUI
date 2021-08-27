using System;
using System.Collections.Generic;
using System.Text;
using Vacscan.Net.XAMARIN.Models.Configs;

namespace Vacscan.Net.XAMARIN.ViewModels
{
    public class PreferencesPageViewModel : BaseViewModel
    {

        public IList<IImmunizationCountryConfig> CountryConfigs { get; set; }

    }
}
