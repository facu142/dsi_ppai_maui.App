using dsi_ppai_maui.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dsi_ppai_maui.Models
{
    public class Llamada
    {
        private string descripcionOperador;
        private string detalleAccionRequerida;
        private string duracion;
        private string encuestaEnviada;
        private string observacionAuditor;
        private List<RespuestaCliente> respuestasDeEncuesta;
        private List<CambioEstado> cambioDeEstado;
        private Cliente cliente;

        public Llamada()
        {
            cambioDeEstado = new List<CambioEstado>();
            respuestasDeEncuesta = new List<RespuestaCliente>();
        }

        public string DescripcionOperador
        {
            get { return descripcionOperador; }
            set { descripcionOperador = value; }
        }

        public string DetalleAccionRequerida
        {
            get { return detalleAccionRequerida; }
            set { detalleAccionRequerida = value; }
        }

        public string Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        public string EncuestaEnviada
        {
            get { return encuestaEnviada; }
            set { encuestaEnviada = value; }
        }

        public string ObservacionAuditor
        {
            get { return observacionAuditor; }
            set { observacionAuditor = value; }
        }

        public List<RespuestaCliente> RespuestasDeEncuesta
        {
            get { return respuestasDeEncuesta; }
            set { respuestasDeEncuesta = value; }
        }

        public List<CambioEstado> CambioDeEstado
        {
            get { return cambioDeEstado; }
            set { cambioDeEstado = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        //public string DeterminarUltimoEstado()
        //{
        //    CambioEstado estadoFinal = new();

        //    foreach (CambioEstado cambioEstado in CambioDeEstado) // En estadoFinal va a terminar quedando el ultimo cambio
        //    {
        //        if (estadoFinal.FechaHoraInicio <= cambioEstado.FechaHoraInicio || estadoFinal == null)
        //        {
        //            estadoFinal = cambioEstado;
        //        }
        //    }

        //    string nombreUltimoEstado = estadoFinal.getEstado().ToString();

        //    return nombreUltimoEstado;

        //}

        public string DeterminarUltimoEstado
        {
            get
            {
                CambioEstado estadoFinal = null;

                foreach (CambioEstado cambioEstado in cambioDeEstado)
                {
                    if (estadoFinal == null || estadoFinal.FechaHoraInicio <= cambioEstado.FechaHoraInicio)
                    {
                        estadoFinal = cambioEstado;
                    }
                }

                if (estadoFinal != null)
                {
                    return estadoFinal.getEstadoNombre().ToString();
                }

                return string.Empty; // Devuelve una cadena vacía en lugar de null si no se encuentra ningún estado.
            }
        }


        public string DeterminarFechaHoraUltimoEstado => cambioDeEstado.LastOrDefault().FechaHoraInicio.ToString();
        public string DeterminarNombreCliente => Cliente.NombreCompleto; // Esto creo q deberia ir en cliente, o sea aca deberia ir una funcion 

        public bool consultarEncuestaRespondida()
        {
            if (this.RespuestasDeEncuesta.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public CambioEstado DeterminarUltimoCambioEstado()
        {
            CambioEstado estadoFinal = null;

            foreach (CambioEstado cambioEstado in cambioDeEstado)
            {
                if (estadoFinal == null || estadoFinal.FechaHoraInicio <= cambioEstado.FechaHoraInicio)
                {
                    estadoFinal = cambioEstado;
                }
            }

            return estadoFinal;
        }
        
        public CambioEstado DeterminarPrimerCambioEstado()
        {
            CambioEstado estadoInicial = null;

            foreach (CambioEstado cambioEstado in cambioDeEstado)
            {
                if (estadoInicial == null || estadoInicial.FechaHoraInicio >= cambioEstado.FechaHoraInicio)
                {
                    estadoInicial = cambioEstado;
                }
            }

            return estadoInicial;
        }

        public bool esDePeriodo(DateTime fechaInicio, DateTime fechaFin) 
        {

            CambioEstado PrimerEstado = this.DeterminarPrimerCambioEstado();
            CambioEstado UltimoEstado = this.DeterminarUltimoCambioEstado();

            if (PrimerEstado.FechaHoraInicio > fechaInicio && UltimoEstado.FechaHoraInicio < fechaFin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public LlamadaDto seleccionarLlamada()
        {
            LlamadaDto llamadaDto = new() //crea objeto de tipo llamada 
            {
                Cliente = this.Cliente.NombreCompleto,
                Duracion = this.Duracion,
                UltimoEstado = DeterminarUltimoEstado
            };

            return llamadaDto;
        }

        //ArmarDetalle
        public ObservableCollection<RespuestaDeLlamadaDto> ArmarDetalle(Encuesta encuesta)
        {
            ObservableCollection<RespuestaDeLlamadaDto> DatosDeRespuestas = new();

            for (int i = 0; i < encuesta.Preguntas.Count ; i++)
            {
                Pregunta pregunta = encuesta.Preguntas[i];
                RespuestaCliente respuesta = RespuestasDeEncuesta[i];
  
                string DescPregunta = pregunta.StrPregunta;
                string DescRespuesta = respuesta.RespuestaSeleccionada.Descripcion;
                string DescEncuesta = encuesta.Descripcion;

                RespuestaDeLlamadaDto respuestaDeLlamadaDto = new(){
                    DescripcionEncuesta = DescEncuesta,
                    DescripcionPregunta = DescPregunta,
                    RespuestaSeleccionada = DescRespuesta
                };

                DatosDeRespuestas.Add(respuestaDeLlamadaDto);
            }
            return DatosDeRespuestas;
        }
    }
}
