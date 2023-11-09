using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dsi_ppai_maui.Models;
using dsi_ppai_maui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
        string estadoActualLlamada;

        [ObservableProperty]
        List<string> respuestasDeEncuestaCliente; // aca puse string

        [ObservableProperty]
        string descripcionDeEncuesta;

        [ObservableProperty]
        List<string> descripcionPreguntas; // aca puse string

        [ObservableProperty]
        string descripcionRespuesta;

        Encuesta EncuestaAsociada;

        [ObservableProperty]
        public List<Encuesta> encuestas; // new

        [ObservableProperty]
        List<RespuestaPosible> respuestasPosibles; // new SEGUN COMO LO DEJE NO HACE FALTA

        public ObservableCollection<Llamada> Llamadas { get; set; } = new ObservableCollection<Llamada>();

        public ObservableCollection<Llamada> LlamadasFiltradas { get; set; } = new ObservableCollection<Llamada>();

        public ObservableCollection<DatosRespuesta> DatosDeRespuestas { get; set; } = new ObservableCollection<DatosRespuesta>();

        IFileSaver fileSaver;
        CancellationTokenSource cancellationTokenSource = new();


        public GestorConsulta(IFileSaver fileSaver)
        {
            this.fileSaver = fileSaver;

            fechaDesde = new();
            fechaHasta = new();

            fechaDesde = DateTime.Now;
            fechaHasta = DateTime.Now;

            RespuestaPosible respuestaPosible0 = new RespuestaPosible( "Muy insatisfecho", "1");
            RespuestaPosible respuestaPosible1 = new RespuestaPosible("Neutral", "2");
            RespuestaPosible respuestaPosible2 = new RespuestaPosible("Satisfecho", "3");
            RespuestaPosible respuestaPosible3 = new RespuestaPosible("Muy Satisfecho", "4");
            RespuestaPosible respuestaPosible4 = new RespuestaPosible("No es probable", "1");
            RespuestaPosible respuestaPosible5 = new RespuestaPosible("Es poco probable", "2");
            RespuestaPosible respuestaPosible6 = new RespuestaPosible("Es probable", "3");
            RespuestaPosible respuestaPosible7 = new RespuestaPosible("Es muy probable", "4");
            RespuestaPosible respuestaPosible8 = new RespuestaPosible("Es bastante probable", "5");
            RespuestaPosible respuestaPosible9 = new RespuestaPosible("Si", "1");
            RespuestaPosible respuestaPosible10 = new RespuestaPosible("No", "2");
            RespuestaPosible respuestaPosible11 = new RespuestaPosible("Si", "1");
            RespuestaPosible respuestaPosible12 = new RespuestaPosible("No", "2");
            RespuestaPosible respuestaPosible13 = new RespuestaPosible("Si", "1");
            RespuestaPosible respuestaPosible14 = new RespuestaPosible("No", "2");
            RespuestaPosible respuestaPosible15 = new RespuestaPosible("Si", "1");
            RespuestaPosible respuestaPosible16 = new RespuestaPosible("No", "2");

        

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

            Encuesta Encuesta1 = new Encuesta( "Conteste ésta encuesta...", DateTime.Now);
            Encuesta Encuesta2 = new Encuesta("Conteste ésta encuesta...", DateTime.Now);
            Encuesta Encuesta3 = new Encuesta("Conteste ésta encuesta...", DateTime.Now);





            Pregunta pregunta1 = new Pregunta("¿Cuan satisfecho estas de los servicios?", respuestas, Encuesta1);
            Pregunta pregunta2 = new Pregunta("¿En una escala del 1 al 5, ¿qué tan probable es que vuelvas a utilizar nuestros productos/servicios en el futuro?",respuestas1, Encuesta2  );

            Pregunta pregunta3 = new Pregunta("¿El personal de atención al cliente fue capaz de resolver tus dudas o inquietudes?", respuestas2, Encuesta3);

            Pregunta pregunta4 = new Pregunta("¿La solución proporcionada a tu consulta/problema fue satisfactoria?", respuestas3, Encuesta1);

            Pregunta pregunta5 = new Pregunta("¿La atención al cliente que recibiste fue amable y cordial?", respuestas4, Encuesta2);

            Pregunta pregunta6 = new Pregunta("¿Recomendarías nuestros productos/servicios a otros?", respuestas5, Encuesta3);
   

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

            respuestaPosible0.setPregunta(pregunta1);
            respuestaPosible1.setPregunta(pregunta1);
            respuestaPosible2.setPregunta(pregunta1);
            respuestaPosible3.setPregunta(pregunta1);

            respuestaPosible4.setPregunta(pregunta2);
            respuestaPosible5.setPregunta(pregunta2);
            respuestaPosible6.setPregunta(pregunta2);
            respuestaPosible7.setPregunta(pregunta2);
            respuestaPosible8.setPregunta(pregunta2);

            respuestaPosible9.setPregunta(pregunta3);
            respuestaPosible10.setPregunta(pregunta3);

            respuestaPosible11.setPregunta(pregunta4);
            respuestaPosible12.setPregunta(pregunta4);

            respuestaPosible13.setPregunta(pregunta5);
            respuestaPosible14.setPregunta(pregunta5);

            respuestaPosible15.setPregunta(pregunta6);
            respuestaPosible16.setPregunta(pregunta6);


            Encuesta1.setPreguntas(preguntas);
            pregunta1.setEncuesta(Encuesta1);
            pregunta2.setEncuesta(Encuesta1);

            Encuesta2.setPreguntas(preguntas1);
            pregunta3.setEncuesta(Encuesta2);
            pregunta4.setEncuesta(Encuesta2);
            
            Encuesta3.setPreguntas(preguntas2);
            pregunta5.setEncuesta(Encuesta3);
            pregunta6.setEncuesta(Encuesta3);


            Estado finalizada = new Estado ("Finalizada");
            Estado iniciada = new Estado("Iniciada");
            Estado enCurso = new Estado("EnCurso");
            Estado cancelado = new Estado("Cancelado");
            Estado pendienteDeEscucha = new Estado("pendienteDeEscucha");
            Estado observacion = new Estado("Observacion");
            Estado correcta = new Estado("Correcta");
            Estado descartado = new Estado("Descartado");


            //cambio de estado de llamada 1
            CambioEstado cambio21 = new CambioEstado(enCurso, DateTime.Now.AddDays(-4));
            CambioEstado cambio31 = new CambioEstado(finalizada, DateTime.Now.AddDays(-3));
            CambioEstado cambio41 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-2));
            CambioEstado cambio51 = new CambioEstado(observacion, DateTime.Now.AddDays(-1));

            //cambio de estado de llamada 2
            CambioEstado cambio12 = new CambioEstado(iniciada, DateTime.Now.AddDays(-10));
            CambioEstado cambio22 = new CambioEstado(enCurso, DateTime.Now.AddDays(-9));
            CambioEstado cambio32 = new CambioEstado(finalizada, DateTime.Now.AddDays(-8));
            CambioEstado cambio42 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-7));
            CambioEstado cambio52 = new CambioEstado(observacion, DateTime.Now.AddDays(-6));

            //cambio de estado de llamada 3
            CambioEstado cambio13 = new CambioEstado(iniciada, DateTime.Now.AddDays(-11));
            CambioEstado cambio23 = new CambioEstado(enCurso, DateTime.Now.AddDays(-10));
            CambioEstado cambio33 = new CambioEstado(finalizada, DateTime.Now.AddDays(-9));
            CambioEstado cambio43 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-8));
            CambioEstado cambio53 = new CambioEstado(observacion, DateTime.Now.AddDays(-7));

            //cambio de estado de llamada 4
            CambioEstado cambio14 = new CambioEstado(iniciada, DateTime.Now.AddDays(-12));
            CambioEstado cambio24 = new CambioEstado(enCurso, DateTime.Now.AddDays(-11));
            CambioEstado cambio34 = new CambioEstado(finalizada, DateTime.Now.AddDays(-10));
            CambioEstado cambio44 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-9));
            CambioEstado cambio54 = new CambioEstado(observacion, DateTime.Now.AddDays(-8));

            //cambio de estado de llamada 5
            CambioEstado cambio15 = new CambioEstado(iniciada, DateTime.Now.AddDays(-6));
            CambioEstado cambio25 = new CambioEstado(enCurso, DateTime.Now.AddDays(-5));
            CambioEstado cambio35 = new CambioEstado(finalizada, DateTime.Now.AddDays(-4));
            CambioEstado cambio45 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-3));
            CambioEstado cambio55 = new CambioEstado(observacion, DateTime.Now.AddDays(-2));

            //cambio de estado de llamada 6
            CambioEstado cambio16 = new CambioEstado(iniciada, DateTime.Now.AddDays(-8));
            CambioEstado cambio26 = new CambioEstado(enCurso, DateTime.Now.AddDays(-7));
            CambioEstado cambio36 = new CambioEstado(finalizada, DateTime.Now.AddDays(-6));
            CambioEstado cambio46 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-5));
            CambioEstado cambio56 = new CambioEstado(correcta, DateTime.Now.AddDays(-4));

            //cambio de estado de llamada 7
            CambioEstado cambio17 = new CambioEstado(iniciada, DateTime.Now.AddDays(-9));
            CambioEstado cambio27 = new CambioEstado(enCurso, DateTime.Now.AddDays(-8));
            CambioEstado cambio37 = new CambioEstado(finalizada, DateTime.Now.AddDays(-7));
            CambioEstado cambio47 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-6));
            CambioEstado cambio57 = new CambioEstado(correcta, DateTime.Now.AddDays(-5));

            //cambio de estado de llamada 8
            CambioEstado cambio18 = new CambioEstado(iniciada, DateTime.Now.AddDays(-7));
            CambioEstado cambio28 = new CambioEstado(enCurso, DateTime.Now.AddDays(-6));
            CambioEstado cambio38 = new CambioEstado(finalizada, DateTime.Now.AddDays(-5));
            CambioEstado cambio48 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-4));
            CambioEstado cambio58 = new CambioEstado(correcta, DateTime.Now.AddDays(-3));

            //cambio de estado de llamada 9
            CambioEstado cambio19 = new CambioEstado(iniciada, DateTime.Now.AddDays(-8));
            CambioEstado cambio29 = new CambioEstado(enCurso, DateTime.Now.AddDays(-7));
            CambioEstado cambio39 = new CambioEstado(finalizada, DateTime.Now.AddDays(-6));
            CambioEstado cambio49 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-5));
            CambioEstado cambio59 = new CambioEstado(correcta, DateTime.Now.AddDays(-4));

            //cambio de estado de llamada 10
            CambioEstado cambio110 = new CambioEstado(iniciada, DateTime.Now.AddDays(-9));
            CambioEstado cambio210 = new CambioEstado(enCurso, DateTime.Now.AddDays(-8));
            CambioEstado cambio310 = new CambioEstado(finalizada, DateTime.Now.AddDays(-7));
            CambioEstado cambio410 = new CambioEstado(pendienteDeEscucha, DateTime.Now.AddDays(-6));
            CambioEstado cambio510 = new CambioEstado(correcta, DateTime.Now.AddDays(-5));


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

            Cliente cliente1 = new Cliente ("John Doe","33999999","351678911" );
            Cliente cliente2 = new Cliente("Jane Smith", "44888888", "351234567");
            Cliente cliente3 = new Cliente("Bob Johnson", "55666666", "351987654");
            Cliente cliente4 = new Cliente("Alice Williams", "66777777", "351111111");
            Cliente cliente5 = new Cliente("Mike Davis", "77444444", "351222222");
            Cliente cliente6 = new Cliente("Juan Mateo Blencio", "44240562", "3885325413");
            Cliente cliente7 = new Cliente("Zoi Lypnik", "47248442", "351263987");
            Cliente cliente8 = new Cliente("Mari Gonzales", "44489654", "351182233");
            Cliente cliente9 = new Cliente("Agustina Sola", "43654897", "0115346798");
            Cliente cliente10 = new Cliente("Valentin Ruiz", "46987531", "3875349784");


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

            RespuestaCliente respuestaCliente1 = new RespuestaCliente (DateTime.Now.AddDays(-5), respuestaPosible1);
            RespuestaCliente respuestaCliente2 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible2);
            RespuestaCliente respuestaCliente3 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible3);
            RespuestaCliente respuestaCliente4 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible4);
            RespuestaCliente respuestaCliente5 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible5);
            RespuestaCliente respuestaCliente6 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible6);
            RespuestaCliente respuestaCliente7 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible7);
            RespuestaCliente respuestaCliente8 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible8);
            RespuestaCliente respuestaCliente9 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible9);
            RespuestaCliente respuestaCliente10 = new RespuestaCliente(DateTime.Now.AddDays(-5), respuestaPosible10);


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

            Llamada llamada1 = new Llamada("Desc", "20", "Detalle de Accion", "Encuesta enviada", "observacion Auditor", cliente1);
            Llamada llamada2 = new Llamada("Desc", "10", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente2);
            Llamada llamada3 = new Llamada("Desc", "20", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente3);
            Llamada llamada4 = new Llamada("Desc", "20", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente4);
            Llamada llamada5 = new Llamada("Desc", "20", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente5);
            Llamada llamada6 = new Llamada("Desc", "20", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente6);
            Llamada llamada7 = new Llamada("Desc", "50", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente7);
            Llamada llamada8 = new Llamada("Desc", "20", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente8);
            Llamada llamada9 = new Llamada("Desc", "20", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente9);
            Llamada llamada10 = new Llamada("Desc", "20", "Detalle de Acción", "Encuesta enviada", "observación Auditor", cliente10);

            llamada1.setCambioDeEstado(cambiosDeEstado1);
            llamada2.setCambioDeEstado(cambiosDeEstado2);
            llamada3.setCambioDeEstado(cambiosDeEstado3);
            llamada4.setCambioDeEstado(cambiosDeEstado4);
            llamada5.setCambioDeEstado(cambiosDeEstado5);
            llamada6.setCambioDeEstado(cambiosDeEstado6);
            llamada7.setCambioDeEstado(cambiosDeEstado7);
            llamada8.setCambioDeEstado(cambiosDeEstado8);
            llamada9.setCambioDeEstado(cambiosDeEstado9);
            llamada10.setCambioDeEstado(cambiosDeEstado10);
            llamada1.setRespuestasDeEncuesta(RespuestasDeEncuesta1);
            llamada2.setRespuestasDeEncuesta(RespuestasDeEncuesta2);
            llamada3.setRespuestasDeEncuesta(RespuestasDeEncuesta3);
            llamada4.setRespuestasDeEncuesta(RespuestasDeEncuesta4);
            llamada5.setRespuestasDeEncuesta(RespuestasDeEncuesta5);
            llamada6.setRespuestasDeEncuesta(RespuestasDeEncuesta6);
            llamada7.setRespuestasDeEncuesta(RespuestasDeEncuesta7);
            llamada8.setRespuestasDeEncuesta(RespuestasDeEncuesta8);
            llamada9.setRespuestasDeEncuesta(RespuestasDeEncuesta9);
            llamada10.setRespuestasDeEncuesta(RespuestasDeEncuesta10);

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


        //aca aplicaremos iterator!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!
        //!!!!!!!!!!!!
        //!!!!!!!!!!!!!
        //!!!!!!!!!!!!
        //!!!!!!!!!!!!!
        //!!!!!!!!!!!!

        [RelayCommand]
        public void FiltrarporPeriodo()
        {
            LlamadasFiltradas.Clear();

            foreach (Llamada llamada in Llamadas)
            {
                if (llamada.ConsultarEncuestaRespondida() && llamada.esDePeriodo(FechaDesde, FechaHasta))
                {
                    LlamadasFiltradas.Add(llamada);
                }
            }
        }


        [RelayCommand]
        public async void Cancelar()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async void TomarSeleccionLlamada(Llamada llamada)
        {

            DatosDeRespuestas.Clear();
            NombreCliente = llamada.getNombreCliente();
            Duracion = llamada.getDuracion();
            EstadoActualLlamada = llamada.DeterminarUltimoEstado;
            RespuestasDeEncuestaCliente = llamada.GetRespuestas();
            EncuestaAsociada = BuscarEncuestaAsociada();
            var navParam = new Dictionary<string, object>();
            navParam.Add("LlamadaSeleccionada", llamada);
            await Shell.Current.GoToAsync(nameof(DetalleLlamadaView), navParam);
        }

        public Encuesta BuscarEncuestaAsociada()
        {
            Encuesta encuestaAsociada = null;
            foreach (Encuesta encuesta in Encuestas)
            {
                if (encuesta.EsEncuestaLlamada(this.RespuestasDeEncuestaCliente))
                {
                    encuestaAsociada = encuesta;
                    return encuestaAsociada;
                }
            }

            return null;
        }


        [RelayCommand]
        public void FechaSeleccionada()
        {
            FiltrarporPeriodo();
        }
     
              // Llamados por DetalleLlamadaView

        [RelayCommand]
        public async void GenerarCSV()
        {
            string str = "nombreCliente;estadoActual;duracion;pregunta;respuesta\n";

            foreach (RespuestaCliente respuestaCliente in LlamadaSeleccionada.getRespuestasDeEncuesta())
            {
                str += NombreCliente + ";" + _llamadaSeleccionada.DeterminarUltimoEstado + ";" + Duracion + ";" + respuestaCliente.getRespuestaSeleccionada().getPregunta().getStrPregunta() + ";" + respuestaCliente.getRespuestaSeleccionada().getDescripcion() + "\n";
            }
            using var stream = new MemoryStream(Encoding.Default.GetBytes(str));
            var path = await fileSaver.SaveAsync(DateTime.Now.ToString()+".csv", stream, cancellationTokenSource.Token);
        }

    }


    //esto directamente se borraria por que no es necesario
    public class DatosRespuesta
    {
        private string descripcionRespuesta; 

        public string DescripcionRespuesta
        {
            get { return descripcionRespuesta; }
            set { descripcionRespuesta = value; }
        }
    }

}
