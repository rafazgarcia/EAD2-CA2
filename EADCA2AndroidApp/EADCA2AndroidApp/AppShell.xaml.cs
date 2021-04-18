using EADCA2AndroidApp.ViewModels;
using EADCA2AndroidApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EADCA2AndroidApp
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
