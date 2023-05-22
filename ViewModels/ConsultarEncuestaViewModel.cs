using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dsi_ppai_maui.Models;
using dsi_ppai_maui.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace dsi_ppai_maui.ViewModels
{
    public partial class ConsultarEncuestaViewModel : ObservableObject
    {

        [ObservableProperty]
        DateOnly fechaDesde;

        [ObservableProperty]
        DateOnly fechaHasta;

        public ObservableCollection<Llamada> Llamadas { get; set; } = new ObservableCollection<Llamada>();

        public ConsultarEncuestaViewModel()
        {
            fechaDesde = new DateOnly();
            fechaHasta = new DateOnly();

            Estado finalizada = new() { Nombre = "Finalizada" };
            Estado iniciada = new() { Nombre = "Iniciada" };

            CambioEstado cambio1 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio2 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            // Listado de cambios de estado
            List<CambioEstado> cambiosDeEstado1 = new();
            List<CambioEstado> cambiosDeEstado2 = new();

            cambiosDeEstado1.Add(cambio1);
            cambiosDeEstado1.Add(cambio2);

            cambiosDeEstado2.Add(cambio1);

            Llamada llamada1 = new() { DescripcionOperador = "Desc 1", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado1 };
            Llamada llamada2 = new() { DescripcionOperador = "Desc 2", Duracion = "10", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado2 };

            Llamadas.Add(llamada1);
            Llamadas.Add(llamada2);
        }

        [RelayCommand]
        public async void GoToDetail( Llamada llamada )
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("DetalleLlamada", llamada);
            await Shell.Current.GoToAsync(nameof(DetalleLlamadaView), navParam);
        }

    }
}
