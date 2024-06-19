using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace AProyecto2.Views
{
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
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
            Contacto nuevoContacto = new Contacto
            {
                Nombre = entryNombre.Text,
                Apellido = entryApellido.Text,
                Telefono = entryTelefono.Text,
                Correo = entryCorreo.Text,
                Direccion = entryDireccion.Text,
                Fecha = datePickerFecha.Date.ToString("dd/MM/yyyy")
            };

            // Guardar el contacto en un archivo en el escritorio del usuario
            bool success = GuardarContactoEnEscritorio(nuevoContacto);

            if (success)
            {
                // Mostrar mensaje de éxito
                await DisplayAlert("Éxito", "Contacto creado y guardado correctamente en el escritorio.", "OK");

                // Limpiar los campos después de confirmar
                LimpiarCampos();
            }
            else
            {
                // Mostrar mensaje de error
                await DisplayAlert("Error", "No se pudo guardar el contacto en el escritorio.", "OK");
            }
        }

        private bool GuardarContactoEnEscritorio(Contacto contacto)
        {
            try
            {
                // Obtener la ruta de la carpeta de escritorio del usuario
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                // Crear la ruta completa del archivo (por ejemplo, usando el nombre del contacto)
                string filePath = Path.Combine(desktopPath, "Registro.Usuario.txt");

                // Crear el contenido del archivo
                string contenidoArchivo = $"Nombre: {contacto.Nombre}\n" +
                                          $"Apellido: {contacto.Apellido}\n" +
                                          $"Teléfono: {contacto.Telefono}\n" +
                                          $"Correo: {contacto.Correo}\n" +
                                          $"Dirección: {contacto.Direccion}\n" +
                                          $"Fecha: {contacto.Fecha}";

                // Escribir el contenido en el archivo
                File.WriteAllText(filePath, contenidoArchivo);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo en el escritorio: {ex.Message}");
                return false;
            }
        }

        private void LimpiarCampos()
        {
            entryNombre.Text = string.Empty;
            entryApellido.Text = string.Empty;
            entryTelefono.Text = string.Empty;
            entryCorreo.Text = string.Empty;
            entryDireccion.Text = string.Empty;
            datePickerFecha.Date = DateTime.Now;
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
