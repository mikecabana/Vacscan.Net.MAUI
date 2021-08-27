
using Vacscan.Net.XAMARIN.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vacscan.Net.XAMARIN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencesPage : ContentPage
    {
        public PreferencesPage()
        {
            InitializeComponent();
            BindingContext = new PreferencesPageViewModel();
        }
    }
}