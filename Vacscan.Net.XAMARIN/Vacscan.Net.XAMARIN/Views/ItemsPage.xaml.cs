using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacscan.Net.XAMARIN.Models;
using Vacscan.Net.XAMARIN.ViewModels;
using Vacscan.Net.XAMARIN.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vacscan.Net.XAMARIN.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}