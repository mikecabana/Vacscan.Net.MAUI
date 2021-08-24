using System;
using Vacscan.Net.XAMARIN.Services;
using Vacscan.Net.XAMARIN.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vacscan.Net.XAMARIN
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
