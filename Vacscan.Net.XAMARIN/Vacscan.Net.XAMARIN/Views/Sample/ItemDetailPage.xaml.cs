using System.ComponentModel;
using Vacscan.Net.XAMARIN.ViewModels;
using Xamarin.Forms;

namespace Vacscan.Net.XAMARIN.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}