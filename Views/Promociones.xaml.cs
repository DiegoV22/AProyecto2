using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace AProyecto2.Views
{
    public partial class Promociones : ContentPage
    {
        public ObservableCollection<Promotion> Promotions50 { get; set; }
        public ObservableCollection<Promotion> Promotions25 { get; set; }

        public Promociones()
        {
            InitializeComponent();
            Promotions50 = new ObservableCollection<Promotion>
            {
                new Promotion { ImageUrl = "fnaf1.jpg" },
 new Promotion { ImageUrl = "fnaf2.jpg" },
 new Promotion { ImageUrl = "fnaf3.jpg" },
 new Promotion { ImageUrl = "fnaf4.jpg" },
 new Promotion { ImageUrl = "fnaf5.jpg" },
 new Promotion { ImageUrl = "fnaf6.jpg" }

            };
            Promotions25 = new ObservableCollection<Promotion>
            {
                new Promotion { ImageUrl = "toy1.jpg" },
 new Promotion { ImageUrl = "toy2.jpg" },
 new Promotion { ImageUrl = "toy3.jpg" },
 new Promotion { ImageUrl = "toy4.jpg" },
 new Promotion { ImageUrl = "toy5.jpg" },
 new Promotion { ImageUrl = "toy6.jpg" }

            };
            BindingContext = this;
        }

        private async void OnInstagramTapped(object sender, EventArgs e)
        {
            var url = "https://www.instagram.com/elmundodelpeluche.ec/";
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }
    }

    public class Promotion
    {
        public string ImageUrl { get; set; }
    }
}
