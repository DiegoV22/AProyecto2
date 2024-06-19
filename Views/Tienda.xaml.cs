using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Maui.Controls;

namespace AProyecto2.Views
{
    public partial class Tienda : ContentPage
    {
        public ObservableCollection<Venta> Ventas { get; set; }

        public Tienda()
        {
            InitializeComponent();
            Ventas = new ObservableCollection<Venta>
            {
                new Venta { Nombre = "fnaf 1", Tamano = "30 cm", Precio = "$10.00", Imagen = "fnaf1.jpg" },
                new Venta { Nombre = "fnaf 2", Tamano = "30 cm", Precio = "$8.00", Imagen = "fnaf2.jpg" },
                new Venta { Nombre = "fnaf 3", Tamano = "30 cm", Precio = "$5.00", Imagen = "fnaf3.jpg" },
                new Venta { Nombre = "fnaf 4", Tamano = "30 cm", Precio = "$12.00", Imagen = "fnaf4.jpg" },
                new Venta { Nombre = "fnaf 5", Tamano = "30 cm", Precio = "$9.00", Imagen = "fnaf5.jpg" },
                new Venta { Nombre = "fnaf 6", Tamano = "30 cm", Precio = "$6.00", Imagen = "fnaf6.jpg" },
                new Venta { Nombre = "toy 1", Tamano = "28 cm", Precio = "$20.00", Imagen = "toy1.jpg" },
                new Venta { Nombre = "toy 2", Tamano = "33 cm", Precio = "$22.00", Imagen = "toy2.jpg" },
                new Venta { Nombre = "toy 3", Tamano = "31 cm", Precio = "$26.00", Imagen = "toy3.jpg" },
                new Venta { Nombre = "toy 4", Tamano = "39 cm", Precio = "$23.00", Imagen = "toy4.jpg" },
                new Venta { Nombre = "toy 5", Tamano = "26 cm", Precio = "$24.00", Imagen = "toy5.jpg" },
                new Venta { Nombre = "toy 6", Tamano = "29 cm", Precio = "$29.00", Imagen = "toy6.jpg" }
            };
            BindingContext = this;
        }

        private async void OnConfirmarVentaClicked(object sender, EventArgs e)
        {
            string nombre = NombreEntry.Text;
            string tamano = TamanoEntry.Text;
            string precio = PrecioEntry.Text;
            DateTime fecha = FechaPicker.Date;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(tamano) || string.IsNullOrWhiteSpace(precio))
            {
                await DisplayAlert("Error", "Por favor, rellena todos los campos.", "OK");
                return;
            }

            string datos = $"Nombre del Peluche: {nombre}\nTamaño del Peluche: {tamano}\nPrecio del Peluche: {precio}\nFecha: {fecha.ToShortDateString()}";

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = Path.Combine(desktopPath, "venta_peluche.txt");

            try
            {
                File.WriteAllText(fileName, datos);
                await DisplayAlert("Éxito", "Venta confirmada y guardada en el escritorio.", "OK");

                // Añadir la venta a la colección para mostrar en la lista, si hay menos de 6 elementos
                if (Ventas.Count < 12) // Aumentamos el límite a 12
                {
                    Ventas.Add(new Venta
                    {
                        Nombre = nombre,
                        Tamano = tamano,
                        Precio = precio,
                        Imagen = "peluche_placeholder.png" // Reemplazar con la imagen correspondiente si existe
                    });
                }
                else
                {
                    await DisplayAlert("Información", "Solo se pueden mostrar 12 ventas a la vez.", "OK");
                }

                // Limpiar las entradas
                NombreEntry.Text = string.Empty;
                TamanoEntry.Text = string.Empty;
                PrecioEntry.Text = string.Empty;
                FechaPicker.Date = DateTime.Today;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Hubo un error al guardar el archivo: {ex.Message}", "OK");
            }
        }

        private void OnVentaSeleccionada(object sender, SelectionChangedEventArgs e)
        {
            var selectedVenta = e.CurrentSelection[0] as Venta;
            if (selectedVenta != null)
            {
                NombreEntry.Text = selectedVenta.Nombre;
                TamanoEntry.Text = selectedVenta.Tamano;
                PrecioEntry.Text = selectedVenta.Precio;
            }
        }
    }

    public class Venta
    {
        public string Nombre { get; set; }
        public string Tamano { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; } // Propiedad para la imagen
    }
}
