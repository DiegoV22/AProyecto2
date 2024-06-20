using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Linq;

namespace AProyecto2.Views
{
    public partial class Registro : ContentPage
    {
        private Contacto currentContacto;
        private ContactosListPage contactosListPage;

        public Registro(ContactosListPage contactosListPage, Contacto contacto = null)
        {
            InitializeComponent();
            this.contactosListPage = contactosListPage;

            if (contacto != null)
            {
                currentContacto = contacto;
                entryNombre.Text = contacto.Nombre;
                entryApellido.Text = contacto.Apellido;
                entryTelefono.Text = contacto.Telefono;
                entryCorreo.Text = contacto.Correo;
                entryDireccion.Text = contacto.Direccion;
                datePickerFecha.Date = DateTime.Parse(contacto.Fecha);
            }
        }

        private async void OnConfirmarClicked(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(entryNombre.Text) ||
                string.IsNullOrWhiteSpace(entryApellido.Text) ||
                string.IsNullOrWhiteSpace(entryTelefono.Text) ||
                string.IsNullOrWhiteSpace(entryCorreo.Text) ||
                string.IsNullOrWhiteSpace(entryDireccion.Text))
            {
                await DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
                return;
            }

            // Crear un objeto de contacto con la información ingresada
            if (currentContacto == null)
            {
                currentContacto = new Contacto();
            }

            currentContacto.Nombre = entryNombre.Text;
            currentContacto.Apellido = entryApellido.Text;
            currentContacto.Telefono = entryTelefono.Text;
            currentContacto.Correo = entryCorreo.Text;
            currentContacto.Direccion = entryDireccion.Text;
            currentContacto.Fecha = datePickerFecha.Date.ToString("dd/MM/yyyy");

            // Guardar el contacto en la lista y el archivo
            GuardarContacto(currentContacto);

            await DisplayAlert("Éxito", "Contacto creado y guardado correctamente.", "OK");

            // Volver a la página de lista de contactos
            await Navigation.PopAsync();
        }

        private void GuardarContacto(Contacto contacto)
        {
            var existingContact = contactosListPage.ContactosList.FirstOrDefault(c => c.Nombre == contacto.Nombre && c.Apellido == contacto.Apellido);

            if (existingContact == null)
            {
                contactosListPage.ContactosList.Add(contacto);
            }
            else
            {
                // Actualizar contacto existente
                existingContact.Telefono = contacto.Telefono;
                existingContact.Correo = contacto.Correo;
                existingContact.Direccion = contacto.Direccion;
                existingContact.Fecha = contacto.Fecha;
            }

            contactosListPage.SaveContacts();
        }
    }

    // Clase de modelo para el contacto
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Fecha { get; set; }
    }
}
