using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EADCA2AndroidApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace EADCA2AndroidApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void GETbyPlatform(object sender, EventArgs e)
        {
            string platform = "Windows, OS X Linux";
            List<Game> fetchedGames = await Game.getAllGames();
                fetchedGames.Count();
            List<Game> fetchedGames2 = await Game.geGamesByPlatform(platform);
            fetchedGames2.Count();
        }
    }
}