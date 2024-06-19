using Microsoft.Maui.Controls;

namespace AProyecto2.Views
{
    public partial class Nosotros : ContentPage
    {
        public Nosotros()
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
