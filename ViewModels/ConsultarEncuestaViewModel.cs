﻿using CommunityToolkit.Mvvm.ComponentModel;
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

            RespuestaPosible respuestaPosible1 = new() { Descripcion = "muy satisfecho", Valor = "1" };
            RespuestaPosible respuestaPosible2 = new() { Descripcion = "Satisfecho", Valor = "2" };

            List<RespuestaPosible> respuestas = new()
            {
                respuestaPosible1,
                respuestaPosible1
            };

            Encuesta Encuesta1 = new() { Descripcion = "Descripcion de la encuesta 1", FechaFinVigencia = DateTime.Now };
            Pregunta pregunta1 = new() { StrPregunta = "¿Cuan satisfecho estas de los servicios?", Respuestas = respuestas, Encuesta = Encuesta1 };
            Pregunta pregunta2 = new() { StrPregunta = "¿Cuan satisfecho estas de los servicios?", Respuestas = respuestas, Encuesta = Encuesta1 };
            List<Pregunta> preguntas = new()
            {
                pregunta1,
                pregunta2
            };
            Encuesta1.Preguntas = preguntas;

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

            Cliente cliente1 = new() { NombreCompleto = "John Doe", Dni = "33999999", nroCelular = "351678911" };
            Cliente cliente2 = new() { NombreCompleto = "Jane Smith", Dni = "44888888", nroCelular = "351234567" };
            Cliente cliente3 = new() { NombreCompleto = "Bob Johnson", Dni = "55666666", nroCelular = "351987654" };
            Cliente cliente4 = new() { NombreCompleto = "Alice Williams", Dni = "66777777", nroCelular = "351111111" };
            Cliente cliente5 = new() { NombreCompleto = "Mike Davis", Dni = "77444444", nroCelular = "351222222" };


            List<RespuestaCliente> RespuestasDeEncuesta1 = new();
            List<RespuestaCliente> RespuestasDeEncuesta2 = new();

            RespuestaCliente respuestaCliente1 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible1 };
            RespuestaCliente respuestaCliente2 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible2 };

            RespuestasDeEncuesta1.Add(respuestaCliente1);
            RespuestasDeEncuesta1.Add(respuestaCliente2);

            RespuestasDeEncuesta2.Add(respuestaCliente1);
            RespuestasDeEncuesta2.Add(respuestaCliente2);

            Llamada llamada1 = new() { DescripcionOperador = "Desc 1", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado1, Cliente = cliente1, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada2 = new() { DescripcionOperador = "Desc 2", Duracion = "10", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado2, Cliente = cliente2, RespuestasDeEncuesta = RespuestasDeEncuesta2 };

            Llamadas.Add(llamada1);
            Llamadas.Add(llamada2);
        }

        [RelayCommand]
        public async void GoToDetail(Llamada llamada)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("DetalleLlamada", llamada);
            await Shell.Current.GoToAsync(nameof(DetalleLlamadaView), navParam);
        }

    }
}
