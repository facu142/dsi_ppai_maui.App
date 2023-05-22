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

            respuestaPosible1.Pregunta = pregunta1;
            respuestaPosible2.Pregunta = pregunta1;

            Encuesta1.Preguntas = preguntas;

            Estado finalizada = new() { Nombre = "Finalizada" };
            Estado iniciada = new() { Nombre = "Iniciada" };
            Estado enCurso = new() { Nombre = "EnCurso" };
            Estado cancelado = new() { Nombre = "Cancelado" };
            Estado pendienteDeEscucha = new() { Nombre = "pendienteDeEscucha" };
            Estado observacion = new() { Nombre = "Observacion" };
            Estado correcta = new() { Nombre = "Correcta" };
            Estado descartado = new() { Nombre = "Descartado" };



            //cambio de estado de llamada 1
            CambioEstado cambio11 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio21 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio31 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio41 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio51 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 2
            CambioEstado cambio12 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio22 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio32 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio42 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio52 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 3
            CambioEstado cambio13 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio23 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio33 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio43 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio53 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 4
            CambioEstado cambio14 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio24 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio34 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio44 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio54 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 5
            CambioEstado cambio15 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio25 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio35 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio45 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio55 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 6
            CambioEstado cambio16 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio26 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio36 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio46 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio56 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 7
            CambioEstado cambio17 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio27 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio37 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio47 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio57 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 8
            CambioEstado cambio18 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio28 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio38 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio48 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio58 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 9
            CambioEstado cambio19 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio29 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio39 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio49 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio59 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 10
            CambioEstado cambio110 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio210 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio310 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio410 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-1) };
            CambioEstado cambio510 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-1) };


            // Listado de cambios de estado
            List<CambioEstado> cambiosDeEstado1 = new();
            List<CambioEstado> cambiosDeEstado2 = new();
            List<CambioEstado> cambiosDeEstado3 = new();
            List<CambioEstado> cambiosDeEstado4 = new();
            List<CambioEstado> cambiosDeEstado5 = new();
            List<CambioEstado> cambiosDeEstado6 = new();
            List<CambioEstado> cambiosDeEstado7 = new();
            List<CambioEstado> cambiosDeEstado8 = new();
            List<CambioEstado> cambiosDeEstado9 = new();
            List<CambioEstado> cambiosDeEstado10 = new();

            cambiosDeEstado1.Add(cambio11);
            cambiosDeEstado1.Add(cambio21);
            cambiosDeEstado1.Add(cambio31);
            cambiosDeEstado1.Add(cambio41);
            cambiosDeEstado1.Add(cambio51);

            cambiosDeEstado2.Add(cambio12);
            cambiosDeEstado2.Add(cambio22);
            cambiosDeEstado2.Add(cambio32);
            cambiosDeEstado2.Add(cambio42);
            cambiosDeEstado2.Add(cambio52);

            cambiosDeEstado3.Add(cambio13);
            cambiosDeEstado3.Add(cambio23);
            cambiosDeEstado3.Add(cambio33);
            cambiosDeEstado3.Add(cambio43);
            cambiosDeEstado3.Add(cambio53);

            cambiosDeEstado4.Add(cambio14);
            cambiosDeEstado4.Add(cambio24);
            cambiosDeEstado4.Add(cambio34);
            cambiosDeEstado4.Add(cambio44);
            cambiosDeEstado4.Add(cambio54);

            cambiosDeEstado5.Add(cambio15);
            cambiosDeEstado5.Add(cambio25);
            cambiosDeEstado5.Add(cambio35);
            cambiosDeEstado5.Add(cambio45);
            cambiosDeEstado5.Add(cambio55);

            cambiosDeEstado6.Add(cambio16);
            cambiosDeEstado6.Add(cambio26);
            cambiosDeEstado6.Add(cambio36);
            cambiosDeEstado6.Add(cambio46);
            cambiosDeEstado6.Add(cambio56);

            cambiosDeEstado7.Add(cambio17);
            cambiosDeEstado7.Add(cambio27);
            cambiosDeEstado7.Add(cambio37);
            cambiosDeEstado7.Add(cambio47);
            cambiosDeEstado7.Add(cambio57);

            cambiosDeEstado8.Add(cambio18);
            cambiosDeEstado8.Add(cambio28);
            cambiosDeEstado8.Add(cambio38);
            cambiosDeEstado8.Add(cambio48);
            cambiosDeEstado8.Add(cambio58);

            cambiosDeEstado9.Add(cambio19);
            cambiosDeEstado9.Add(cambio29);
            cambiosDeEstado9.Add(cambio39);
            cambiosDeEstado9.Add(cambio49);
            cambiosDeEstado9.Add(cambio59);

            cambiosDeEstado10.Add(cambio110);
            cambiosDeEstado10.Add(cambio210);
            cambiosDeEstado10.Add(cambio310);
            cambiosDeEstado10.Add(cambio410);
            cambiosDeEstado10.Add(cambio510);

            Cliente cliente1 = new() { NombreCompleto = "John Doe", Dni = "33999999", nroCelular = "351678911" };
            Cliente cliente2 = new() { NombreCompleto = "Jane Smith", Dni = "44888888", nroCelular = "351234567" };
            Cliente cliente3 = new() { NombreCompleto = "Bob Johnson", Dni = "55666666", nroCelular = "351987654" };
            Cliente cliente4 = new() { NombreCompleto = "Alice Williams", Dni = "66777777", nroCelular = "351111111" };
            Cliente cliente5 = new() { NombreCompleto = "Mike Davis", Dni = "77444444", nroCelular = "351222222" };
            Cliente cliente6 = new() { NombreCompleto = "Juan Mateo Blencio", Dni = "44240562", nroCelular = "3885325413" };
            Cliente cliente7 = new() { NombreCompleto = "Zoi Lypnik", Dni = "47248442", nroCelular = "351263987" };
            Cliente cliente8 = new() { NombreCompleto = "Mari Gonzales", Dni = "44489654", nroCelular = "351182233" };
            Cliente cliente9 = new() { NombreCompleto = "Agustina Sola", Dni = "43654897", nroCelular = "0115346798" };
            Cliente cliente10 = new() { NombreCompleto = "Valentin Ruiz", Dni = "46987531", nroCelular = "3875349784" };


            List<RespuestaCliente> RespuestasDeEncuesta1 = new();
            List<RespuestaCliente> RespuestasDeEncuesta2 = new();

            RespuestaCliente respuestaCliente1 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible1 };
            RespuestaCliente respuestaCliente2 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible2 };

            RespuestasDeEncuesta1.Add(respuestaCliente1);
            RespuestasDeEncuesta1.Add(respuestaCliente2);

            RespuestasDeEncuesta2.Add(respuestaCliente1);
            RespuestasDeEncuesta2.Add(respuestaCliente2);

            Llamada llamada1 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado1, Cliente = cliente1, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada2 = new() { DescripcionOperador = "Desc ", Duracion = "10", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado2, Cliente = cliente2, RespuestasDeEncuesta = RespuestasDeEncuesta2 };
            Llamada llamada3 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado3, Cliente = cliente3, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada4 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado4, Cliente = cliente4, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada5 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado5, Cliente = cliente5, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada6 = new() { DescripcionOperador = "Desc  ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado6, Cliente = cliente6, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada7 = new() { DescripcionOperador = "Desc ", Duracion = "50", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado7, Cliente = cliente7, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada8 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado8, Cliente = cliente8, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada9 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado9, Cliente = cliente9, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada10 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado10, Cliente = cliente10, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamadas.Add(llamada1);
            Llamadas.Add(llamada2);
            Llamadas.Add(llamada3);
            Llamadas.Add(llamada4);
            Llamadas.Add(llamada5);
            Llamadas.Add(llamada6);
            Llamadas.Add(llamada7);
            Llamadas.Add(llamada8);
            Llamadas.Add(llamada9);
            Llamadas.Add(llamada10);
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
