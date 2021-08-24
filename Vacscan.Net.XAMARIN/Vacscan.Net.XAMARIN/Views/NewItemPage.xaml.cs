using System;
using System.Collections.Generic;
using System.ComponentModel;
using Vacscan.Net.XAMARIN.Models;
using Vacscan.Net.XAMARIN.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vacscan.Net.XAMARIN.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}