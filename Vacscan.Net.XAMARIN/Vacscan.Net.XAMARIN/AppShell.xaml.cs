using System;
using System.Collections.Generic;
using Vacscan.Net.XAMARIN.ViewModels;
using Vacscan.Net.XAMARIN.Views;
using Xamarin.Forms;

namespace Vacscan.Net.XAMARIN
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
