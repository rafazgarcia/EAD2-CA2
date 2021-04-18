using EADCA2AndroidApp.Services;
using EADCA2AndroidApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EADCA2AndroidApp
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
