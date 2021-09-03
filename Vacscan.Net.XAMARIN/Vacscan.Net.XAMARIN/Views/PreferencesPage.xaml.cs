
using System;
using Vacscan.Net.XAMARIN.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vacscan.Net.XAMARIN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencesPage : ContentPage
    {
        private readonly PreferencesViewModel _viewModel;

        public PreferencesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PreferencesViewModel();
        }

        public void OnCountryChanged(object sender, EventArgs e)
        {
            _viewModel.OnCountryChanged(sender, e);

            string[] regions = _viewModel.AvailableRegions;
            if (regions.Length > 0)
            {
                foreach (string region in regions)
                {
                    regionPicker.Items.Add(region);
                }
            }
        }

        public void OnRegionChanged(object sender, EventArgs e)
        {
            _viewModel.OnRegionChanged(sender, e);
        }
    }
}