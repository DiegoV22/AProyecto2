using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace AProyecto2.Views
{
    public partial class ContactosListPage : ContentPage
    {
        public ObservableCollection<Contacto> ContactosList { get; set; }

        public ContactosListPage()
        {
            InitializeComponent();
            LoadContacts();
            BindingContext = this;
        }

        private void LoadContacts()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = Path.Combine(desktopPath, "Registro.Usuario.txt");

            ContactosList = new ObservableCollection<Contacto>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 6)
                {
                    ContactosList.Add(new Contacto
                    {
                        Nombre = lines[i].Substring(7),
                        Apellido = lines[i + 1].Substring(9),
                        Telefono = lines[i + 2].Substring(10),
                        Correo = lines[i + 3].Substring(8),
                        Direccion = lines[i + 4].Substring(11),
                        Fecha = lines[i + 5].Substring(7)
                    });
                }
            }
        }

        public void SaveContacts()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = Path.Combine(desktopPath, "Registro.Usuario.txt");

            var content = "";
            foreach (var contacto in ContactosList)
            {
                content += $"Nombre: {contacto.Nombre}\n" +
                           $"Apellido: {contacto.Apellido}\n" +
                           $"Teléfono: {contacto.Telefono}\n" +
                           $"Correo: {contacto.Correo}\n" +
                           $"Dirección: {contacto.Direccion}\n" +
                           $"Fecha: {contacto.Fecha}\n";
            }
            File.WriteAllText(filePath, content);
        }

        private async void OnCrearNuevoContactoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro(this));
        }

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var contacto = button.CommandParameter as Contacto;
            await Navigation.PushAsync(new Registro(this, contacto));
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var contacto = button.CommandParameter as Contacto;
            ContactosList.Remove(contacto);
            SaveContacts();
        }
    }
}
