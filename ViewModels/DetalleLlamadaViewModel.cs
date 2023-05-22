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
            
        }
    }
}
