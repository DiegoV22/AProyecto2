using Microsoft.Maui.Controls;

namespace AProyecto2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnInstagramTapped(object sender, EventArgs e)
        {
            var url = "https://www.instagram.com/elmundodelpeluche.ec/";
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }
    }
}

