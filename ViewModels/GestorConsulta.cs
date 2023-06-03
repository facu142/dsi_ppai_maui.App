using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dsi_ppai_maui.Dto;
using dsi_ppai_maui.Models;
using dsi_ppai_maui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.ViewModels
{
    [QueryProperty(nameof(LlamadaSeleccionada), "LlamadaSeleccionada")]
    public partial class GestorConsulta : ObservableObject
    {

        [ObservableProperty]
        private Llamada _llamadaSeleccionada = new();

        [ObservableProperty]
        DateTime fechaDesde;

        [ObservableProperty]
        DateTime fechaHasta;

        [ObservableProperty]
        string estadoActual;

        [ObservableProperty]
        string nombreCliente;

        [ObservableProperty]
        string duracion;

        [ObservableProperty]
        List<RespuestaCliente> respuestaDeEncuesta;

        [ObservableProperty]
        string descripcionDeEncuesta;

        [ObservableProperty]
        string descripcionPregunta;

        [ObservableProperty]
        string descripcionRespuesta;

        public ObservableCollection<Llamada> Llamadas { get; set; } = new ObservableCollection<Llamada>();

        public ObservableCollection<Llamada> LlamadasFiltradas { get; set; } = new ObservableCollection<Llamada>();

        public ObservableCollection<RespuestasDeLlamadaDto> RespuestasDeEncuestas { get; set; } = new ObservableCollection<RespuestasDeLlamadaDto>();

        IFileSaver fileSaver;
        CancellationTokenSource cancellationTokenSource = new();


        public GestorConsulta(IFileSaver fileSaver)
        {
            this.fileSaver = fileSaver;

            fechaDesde = new ();
            fechaHasta = new ();

            fechaDesde = DateTime.Now;
            fechaHasta = DateTime.Now;

            RespuestaPosible respuestaPosible0 = new() { Descripcion = "Muy insatisfecho", Valor = "1" };
            RespuestaPosible respuestaPosible1 = new() { Descripcion = "Neutral", Valor = "2" };
            RespuestaPosible respuestaPosible2 = new() { Descripcion = "Satisfecho", Valor = "3" };
            RespuestaPosible respuestaPosible3 = new() { Descripcion = "Muy Satisfecho", Valor = "4" };
            RespuestaPosible respuestaPosible4 = new() { Descripcion = "No es probable", Valor = "1" };
            RespuestaPosible respuestaPosible5 = new() { Descripcion = "Es poco probable", Valor = "2" };
            RespuestaPosible respuestaPosible6 = new() { Descripcion = "Es probable", Valor = "3" };
            RespuestaPosible respuestaPosible7 = new() { Descripcion = "Es muy probable", Valor = "4" };
            RespuestaPosible respuestaPosible8 = new() { Descripcion = "Es bastante probable", Valor = "5" };
            RespuestaPosible respuestaPosible9 = new() { Descripcion = "Si", Valor = "1" };
            RespuestaPosible respuestaPosible10 = new() { Descripcion = "No", Valor = "2" };
            RespuestaPosible respuestaPosible11 = new() { Descripcion = "Si", Valor = "1" };
            RespuestaPosible respuestaPosible12 = new() { Descripcion = "No", Valor = "2" };
            RespuestaPosible respuestaPosible13 = new() { Descripcion = "Si", Valor = "1" };
            RespuestaPosible respuestaPosible14 = new() { Descripcion = "No", Valor = "2" };
            RespuestaPosible respuestaPosible15 = new() { Descripcion = "Si", Valor = "1" };
            RespuestaPosible respuestaPosible16 = new() { Descripcion = "No", Valor = "2" };

            /*1 - Muy insatisfecho
            2 - Insatisfecho
            3 - Algo insatisfecho
            4 - Neutral
            5 - Algo satisfecho
            6 - Satisfecho
            7 - Bastante satisfecho
            8 - Muy satisfecho
            9 - Extremadamente satisfecho
            10 - Completamente satisfecho*/

            List<RespuestaPosible> respuestas = new()
            {
                respuestaPosible0,
                respuestaPosible1,
                respuestaPosible2,
                respuestaPosible3,

            };
            List<RespuestaPosible> respuestas1 = new()
            {

                respuestaPosible4,
                respuestaPosible5,
                respuestaPosible6,
                respuestaPosible7,
                respuestaPosible8,

            };
            List<RespuestaPosible> respuestas2 = new()
            {
                respuestaPosible9,
                respuestaPosible10,
            };
            List<RespuestaPosible> respuestas3 = new()
            {
                respuestaPosible11,
                respuestaPosible12,
            };
            List<RespuestaPosible> respuestas4 = new()
            {
                respuestaPosible13,
                respuestaPosible14,
            };
            List<RespuestaPosible> respuestas5 = new()
            {
                respuestaPosible15,
                respuestaPosible16,
            };

            /* Cada encuesta tiene 2 preguntas y cada pregunta tiene 2 respuestas posibles y cada respuesta de cliente es una respuesta posible*/

            Encuesta Encuesta1 = new() { Descripcion = "Conteste ésta encuesta...", FechaFinVigencia = DateTime.Now };
            Encuesta Encuesta2 = new() { Descripcion = "Conteste ésta encuesta...", FechaFinVigencia = DateTime.Now };
            Encuesta Encuesta3 = new() { Descripcion = "Conteste ésta encuesta...", FechaFinVigencia = DateTime.Now };





            Pregunta pregunta1 = new() { StrPregunta = "¿Cuan satisfecho estas de los servicios?", Respuestas = respuestas, Encuesta = Encuesta1 };
            Pregunta pregunta2 = new() { StrPregunta = "¿En una escala del 1 al 5, ¿qué tan probable es que vuelvas a utilizar nuestros productos/servicios en el futuro?", Respuestas = respuestas1, Encuesta = Encuesta2 };
            Pregunta pregunta3 = new() { StrPregunta = "¿El personal de atención al cliente fue capaz de resolver tus dudas o inquietudes?", Respuestas = respuestas2, Encuesta = Encuesta3 };
            Pregunta pregunta4 = new() { StrPregunta = "¿La solución proporcionada a tu consulta/problema fue satisfactoria?", Respuestas = respuestas3, Encuesta = Encuesta1 };
            Pregunta pregunta5 = new() { StrPregunta = "¿La atención al cliente que recibiste fue amable y cordial?", Respuestas = respuestas4, Encuesta = Encuesta2 };
            Pregunta pregunta6 = new() { StrPregunta = "¿Recomendarías nuestros productos/servicios a otros?", Respuestas = respuestas5, Encuesta = Encuesta3 };


            List<Pregunta> preguntas = new()
            {
                pregunta1,
                pregunta2,
                pregunta3,
                pregunta4,
                pregunta5,
                pregunta6

            };

            List<Pregunta> preguntas1 = new()
            {
                pregunta3,
                pregunta4
            };

            List<Pregunta> preguntas2 = new()
            {
                pregunta4,
                pregunta5
            };

            respuestaPosible0.Pregunta = pregunta1;
            respuestaPosible1.Pregunta = pregunta1;
            respuestaPosible2.Pregunta = pregunta1;
            respuestaPosible3.Pregunta = pregunta1;

            respuestaPosible4.Pregunta = pregunta2;
            respuestaPosible5.Pregunta = pregunta2;
            respuestaPosible6.Pregunta = pregunta2;
            respuestaPosible7.Pregunta = pregunta2;
            respuestaPosible8.Pregunta = pregunta2;

            respuestaPosible9.Pregunta = pregunta3;
            respuestaPosible10.Pregunta = pregunta3;

            respuestaPosible11.Pregunta = pregunta4;
            respuestaPosible12.Pregunta = pregunta4;

            respuestaPosible13.Pregunta = pregunta5;
            respuestaPosible14.Pregunta = pregunta5;

            respuestaPosible15.Pregunta = pregunta6;
            respuestaPosible16.Pregunta = pregunta6;


            Encuesta1.Preguntas = preguntas;
            pregunta1.Encuesta = Encuesta1;
            pregunta2.Encuesta = Encuesta1;

            Encuesta2.Preguntas = preguntas1;
            pregunta3.Encuesta = Encuesta1;
            pregunta4.Encuesta = Encuesta1;

            Encuesta3.Preguntas = preguntas2;
            pregunta5.Encuesta = Encuesta1;
            pregunta6.Encuesta = Encuesta1;


            Estado finalizada = new() { Nombre = "Finalizada" };
            Estado iniciada = new() { Nombre = "Iniciada" };
            Estado enCurso = new() { Nombre = "EnCurso" };
            Estado cancelado = new() { Nombre = "Cancelado" };
            Estado pendienteDeEscucha = new() { Nombre = "pendienteDeEscucha" };
            Estado observacion = new() { Nombre = "Observacion" };
            Estado correcta = new() { Nombre = "Correcta" };
            Estado descartado = new() { Nombre = "Descartado" };


            //cambio de estado de llamada 1
            CambioEstado cambio21 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-4) };
            CambioEstado cambio31 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-3) };
            CambioEstado cambio41 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-2) };
            CambioEstado cambio51 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-1) };

            //cambio de estado llamada 2
            CambioEstado cambio12 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-10) };
            CambioEstado cambio22 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-9) };
            CambioEstado cambio32 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-8) };
            CambioEstado cambio42 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-7) };
            CambioEstado cambio52 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-6) };

            //cambio de estado llamada 3
            CambioEstado cambio13 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-11) };
            CambioEstado cambio23 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-10) };
            CambioEstado cambio33 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-9) };
            CambioEstado cambio43 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-8) };
            CambioEstado cambio53 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-7) };

            //cambio de estado llamada 4
            CambioEstado cambio14 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-12) };
            CambioEstado cambio24 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-11) };
            CambioEstado cambio34 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-10) };
            CambioEstado cambio44 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-9) };
            CambioEstado cambio54 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-8) };

            //cambio de estado llamada 5
            CambioEstado cambio15 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-6) };
            CambioEstado cambio25 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-5) };
            CambioEstado cambio35 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-4) };
            CambioEstado cambio45 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-3) };
            CambioEstado cambio55 = new() { Estado = observacion, FechaHoraInicio = DateTime.Now.AddDays(-2) };

            //cambio de estado llamada 6
            CambioEstado cambio16 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-8) };
            CambioEstado cambio26 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-7) };
            CambioEstado cambio36 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-6) };
            CambioEstado cambio46 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-5) };
            CambioEstado cambio56 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-4) };

            //cambio de estado llamada 7
            CambioEstado cambio17 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-9) };
            CambioEstado cambio27 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-8) };
            CambioEstado cambio37 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-7) };
            CambioEstado cambio47 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-6) };
            CambioEstado cambio57 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-5) };

            //cambio de estado llamada 8
            CambioEstado cambio18 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-7) };
            CambioEstado cambio28 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-6) };
            CambioEstado cambio38 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-5) };
            CambioEstado cambio48 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-4) };
            CambioEstado cambio58 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-3) };

            //cambio de estado llamada 9
            CambioEstado cambio19 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-8) };
            CambioEstado cambio29 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-7) };
            CambioEstado cambio39 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-6) };
            CambioEstado cambio49 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-5) };
            CambioEstado cambio59 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-4) };

            //cambio de estado llamada 10
            CambioEstado cambio110 = new() { Estado = iniciada, FechaHoraInicio = DateTime.Now.AddDays(-9) };
            CambioEstado cambio210 = new() { Estado = enCurso, FechaHoraInicio = DateTime.Now.AddDays(-8) };
            CambioEstado cambio310 = new() { Estado = finalizada, FechaHoraInicio = DateTime.Now.AddDays(-7) };
            CambioEstado cambio410 = new() { Estado = pendienteDeEscucha, FechaHoraInicio = DateTime.Now.AddDays(-6) };
            CambioEstado cambio510 = new() { Estado = correcta, FechaHoraInicio = DateTime.Now.AddDays(-5) };


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

            //cambiosDeEstado1.Add(cambio11);
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

            Cliente cliente1 = new() { NombreCompleto = "John Doe", Dni = "33999999", NroCelular = "351678911" };
            Cliente cliente2 = new() { NombreCompleto = "Jane Smith", Dni = "44888888", NroCelular = "351234567" };
            Cliente cliente3 = new() { NombreCompleto = "Bob Johnson", Dni = "55666666", NroCelular = "351987654" };
            Cliente cliente4 = new() { NombreCompleto = "Alice Williams", Dni = "66777777", NroCelular = "351111111" };
            Cliente cliente5 = new() { NombreCompleto = "Mike Davis", Dni = "77444444", NroCelular = "351222222" };
            Cliente cliente6 = new() { NombreCompleto = "Juan Mateo Blencio", Dni = "44240562", NroCelular = "3885325413" };
            Cliente cliente7 = new() { NombreCompleto = "Zoi Lypnik", Dni = "47248442", NroCelular = "351263987" };
            Cliente cliente8 = new() { NombreCompleto = "Mari Gonzales", Dni = "44489654", NroCelular = "351182233" };
            Cliente cliente9 = new() { NombreCompleto = "Agustina Sola", Dni = "43654897", NroCelular = "0115346798" };
            Cliente cliente10 = new() { NombreCompleto = "Valentin Ruiz", Dni = "46987531", NroCelular = "3875349784" };


            List<RespuestaCliente> RespuestasDeEncuesta1 = new();
            List<RespuestaCliente> RespuestasDeEncuesta2 = new();
            List<RespuestaCliente> RespuestasDeEncuesta3 = new();
            List<RespuestaCliente> RespuestasDeEncuesta4 = new();
            List<RespuestaCliente> RespuestasDeEncuesta5 = new();
            List<RespuestaCliente> RespuestasDeEncuesta6 = new();
            List<RespuestaCliente> RespuestasDeEncuesta7 = new();
            List<RespuestaCliente> RespuestasDeEncuesta8 = new();
            List<RespuestaCliente> RespuestasDeEncuesta9 = new();
            List<RespuestaCliente> RespuestasDeEncuesta10 = new();

            RespuestaCliente respuestaCliente1 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible1 };
            RespuestaCliente respuestaCliente2 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible2 };
            RespuestaCliente respuestaCliente3 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible3 };
            RespuestaCliente respuestaCliente4 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible4 };
            RespuestaCliente respuestaCliente5 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible5 };
            RespuestaCliente respuestaCliente6 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible6 };
            RespuestaCliente respuestaCliente7 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible7 };
            RespuestaCliente respuestaCliente8 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible8 };
            RespuestaCliente respuestaCliente9 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible9 };
            RespuestaCliente respuestaCliente10 = new() { FechaEncuesta = DateTime.Now.AddDays(-5), RespuestaSeleccionada = respuestaPosible10 };

            RespuestasDeEncuesta1.Add(respuestaCliente1);
            RespuestasDeEncuesta1.Add(respuestaCliente2);

            RespuestasDeEncuesta2.Add(respuestaCliente3);
            RespuestasDeEncuesta2.Add(respuestaCliente4);
            RespuestasDeEncuesta2.Add(respuestaCliente8);

            RespuestasDeEncuesta3.Add(respuestaCliente5);
            RespuestasDeEncuesta3.Add(respuestaCliente6);

            RespuestasDeEncuesta4.Add(respuestaCliente7);
            RespuestasDeEncuesta4.Add(respuestaCliente8);
            RespuestasDeEncuesta4.Add(respuestaCliente5);

            RespuestasDeEncuesta5.Add(respuestaCliente9);
            RespuestasDeEncuesta5.Add(respuestaCliente10);

            RespuestasDeEncuesta6.Add(respuestaCliente1);
            RespuestasDeEncuesta6.Add(respuestaCliente3);

            RespuestasDeEncuesta7.Add(respuestaCliente1);
            RespuestasDeEncuesta7.Add(respuestaCliente3);
            RespuestasDeEncuesta7.Add(respuestaCliente3);

            RespuestasDeEncuesta8.Add(respuestaCliente4);
            RespuestasDeEncuesta8.Add(respuestaCliente5);

            RespuestasDeEncuesta9.Add(respuestaCliente1);
            RespuestasDeEncuesta9.Add(respuestaCliente5);
            RespuestasDeEncuesta9.Add(respuestaCliente7);

            RespuestasDeEncuesta10.Add(respuestaCliente4);
            RespuestasDeEncuesta10.Add(respuestaCliente3);

            Llamada llamada1 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado1, Cliente = cliente1, RespuestasDeEncuesta = RespuestasDeEncuesta1 };
            Llamada llamada2 = new() { DescripcionOperador = "Desc ", Duracion = "10", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado2, Cliente = cliente2, RespuestasDeEncuesta = RespuestasDeEncuesta2 };
            Llamada llamada3 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado3, Cliente = cliente3, RespuestasDeEncuesta = RespuestasDeEncuesta3 };
            Llamada llamada4 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado4, Cliente = cliente4, RespuestasDeEncuesta = RespuestasDeEncuesta4 };
            Llamada llamada5 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado5, Cliente = cliente5, RespuestasDeEncuesta = RespuestasDeEncuesta5 };
            Llamada llamada6 = new() { DescripcionOperador = "Desc  ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado6, Cliente = cliente6, RespuestasDeEncuesta = RespuestasDeEncuesta6 };
            Llamada llamada7 = new() { DescripcionOperador = "Desc ", Duracion = "50", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado7, Cliente = cliente7, RespuestasDeEncuesta = RespuestasDeEncuesta7 };
            Llamada llamada8 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado8, Cliente = cliente8, RespuestasDeEncuesta = RespuestasDeEncuesta8 };
            Llamada llamada9 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado9, Cliente = cliente9, RespuestasDeEncuesta = RespuestasDeEncuesta9 };
            Llamada llamada10 = new() { DescripcionOperador = "Desc ", Duracion = "20", DetalleAccionRequerida = "Detalle de Accion", EncuestaEnviada = "Encuesta enviada", ObservacionAuditor = "observacion Auditor", CambioDeEstado = cambiosDeEstado10, Cliente = cliente10, RespuestasDeEncuesta = RespuestasDeEncuesta10 };

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


        // Metodos llamados por el HomeView
        [RelayCommand]
        public async void ConsultarEncuesta()
        {
            await Shell.Current.GoToAsync(nameof(ConsultarEncuestaView));
        }

        // Llamados por ConsultarEncuestaView

        [RelayCommand]
        public async void Cancelar()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async void TomarSeleccionLlamada(Llamada llamada)
        {

            // TODO: borrar estas tres lineas 
            //EstadoActual = llamada.DeterminarUltimoEstado();
            //NombreCliente = llamada.Cliente.NombreCompleto;
            //Duracion = llamada.Duracion;

            // y hacer llamada.tomarSeleccionLlamada, devuelve nombre de cliente, duracion y ultimo estado

            RespuestasDeEncuestas = llamada.getRespuestasDeEncuesta();

            var navParam = new Dictionary<string, object>();
            navParam.Add("LlamadaSeleccionada", llamada);
            await Shell.Current.GoToAsync(nameof(DetalleLlamadaView), navParam);
        }

        [RelayCommand]
        public void FechaSeleccionada()
        {
            FiltrarporPeriodo();
        }

        [RelayCommand]
        public void FiltrarporPeriodo()
        {
            LlamadasFiltradas.Clear();
            
            foreach(Llamada llamada in Llamadas)
            {
                if (llamada.consultarEncuestaRespondida() && llamada.esDePeriodo(FechaDesde, FechaHasta))
                {
                    LlamadasFiltradas.Add(llamada);
                }
            }
        }

        // Llamados por DetalleLlamadaView
        [RelayCommand]
        public async void GenerarCSV()
        {
            string str = "nombreCliente;estadoActual;duracion;pregunta;respuesta\n";

            foreach (RespuestaCliente respuestaCliente in _llamadaSeleccionada.RespuestasDeEncuesta)
            {
                str += NombreCliente + ";" + EstadoActual + ";" + Duracion + ";" + respuestaCliente.RespuestaSeleccionada.Pregunta.StrPregunta + ";" + respuestaCliente.RespuestaSeleccionada.Descripcion + "\n";
            }
            using var stream = new MemoryStream(Encoding.Default.GetBytes(str));
            var path = await fileSaver.SaveAsync("suscribe.csv", stream, cancellationTokenSource.Token);
        }
    }
}
