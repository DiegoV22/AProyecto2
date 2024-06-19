using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace AProyecto2.Views
{
    public partial class Contactos : ContentPage
    {
        public ObservableCollection<ContactInfo> ContactosList { get; set; }

        public Contactos()
        {
            InitializeComponent();

            ContactosList = new ObservableCollection<ContactInfo>
            {
                new ContactInfo
                {
                    Image = "instagram.png",
                    Text1 = "Instagram",
                    Text2 = "El Mundo Del Peluche",
                    Text3 = "!Siguenos!"
                },
                new ContactInfo
                {
                    Image = "face.png",
                    Text1 = "Facebook",
                    Text2 = "El Mundo Del Peluche",
                    Text3 = "!Siguenos!"
                },
                new ContactInfo
                {
                    Image = "mail.png",
                    Text1 = "Mail",
                    Text2 = "diego.vega.aguilera@udla.edu.ec",
                    Text3 = "!Escribenos!"
                },
                new ContactInfo
                {
                    Image = "telefono.jpg",
                    Text1 = "Telefono",
                    Text2 = "0969088003",
                    Text3 = "!LLamanos!"
                }
            };

            collectionView.ItemsSource = ContactosList;
        }

        private async void OnInstagramTapped(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new Uri("https://www.instagram.com/elmundodelpeluche.ec/"));
        }

        private async void OnFacebookTapped(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new Uri("https://es-la.facebook.com/elmundodelpelucheecuador/"));
        }
    }

    // Clase de modelo para la información de contacto
    public class ContactInfo
    {
        public string Image { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
    }
}
