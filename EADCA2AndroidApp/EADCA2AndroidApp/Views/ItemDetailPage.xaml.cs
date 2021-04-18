using EADCA2AndroidApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EADCA2AndroidApp.Views
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