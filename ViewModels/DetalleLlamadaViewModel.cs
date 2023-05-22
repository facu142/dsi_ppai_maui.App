using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dsi_ppai_maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dsi_ppai_maui.ViewModels
{
    [QueryProperty(nameof(DetalleLlamada), "DetalleLlamada")]

    public partial class DetalleLlamadaViewModel : ObservableObject
    {
        IFileSaver fileSaver;
        CancellationTokenSource cancellationTokenSource = new();

        [ObservableProperty]
        private Llamada _detalleLlamada;


        public DetalleLlamadaViewModel(IFileSaver fileSaver) 
        {
            this.fileSaver = fileSaver;
        }


        [RelayCommand]
        public async void GenerarCSV()
        {

            string str = "nombreCliente;estadoActual;duracion;pregunta;respuesta\n";

            using var stream = new MemoryStream(Encoding.Default.GetBytes(str));
            var path = await fileSaver.SaveAsync("suscribe.csv", stream, cancellationTokenSource.Token);
            
            

            //fileSaverResult.Text = path.FilePath;


            /*
             // Ruta del archivo CSV
            string rutaPorDefecto = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string rutaArchivo = Path.Combine(rutaPorDefecto, "archivo.csv");

            // Crear el archivo CSV
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                // Escribir el encabezado
                writer.WriteLine("nombre del cliente,estado actual,duración,respuesta");

                // Obtener los detalles de la llamada
                string nombreCliente = _detalleLlamada.Cliente.NombreCompleto;
                string estadoActual = _detalleLlamada.CambioDeEstado.Last().Estado.Nombre;
                string duracion = _detalleLlamada.Duracion;

                // Generar una línea con los datos de la llamada
                string linea = $"{nombreCliente},{estadoActual},{duracion}";

                // Escribir la línea en el archivo
                writer.WriteLine(linea);

                // Escribir una línea para cada respuesta de la encuesta
                foreach (var respuesta in _detalleLlamada.RespuestasDeEncuesta)
                {
                    // Obtener la descripción de la pregunta y la respuesta
                    string descripcionPregunta = respuesta.RespuestaSeleccionada.Pregunta.StrPregunta;
                    string respuestaTexto = respuesta.RespuestaSeleccionada.Descripcion;

                    // Generar una línea con los datos de la respuesta
                    string lineaRespuesta = $",,{descripcionPregunta},{respuestaTexto}";

                    // Escribir la línea en el archivo
                    writer.WriteLine(lineaRespuesta);
                }
            }
            */

        }
    }
}
