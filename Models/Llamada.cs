using System;
using System.Collections.Generic;
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
        //constructor
        public Llamada(
      string descripcionOperador,
      string detalleAccionRequerida,
      string duracion,
      string encuestaEnviada,
      string observacionAuditor,
      Cliente cliente)
        {
            this.descripcionOperador = descripcionOperador;
            this.duracion = duracion;
            this.detalleAccionRequerida = detalleAccionRequerida;
            this.encuestaEnviada = encuestaEnviada;
            this.observacionAuditor = observacionAuditor;
             this.cliente = cliente;

        }

        public Llamada()
        {
        }

        public string getDescripcionOperador()
            {
                return descripcionOperador;
            }

            public void setDescripcionOperador(string value)
            {
                descripcionOperador = value;
            }

            public string getDetalleAccionRequerida()
            {
                return detalleAccionRequerida;
            }

            public void setDetalleAccionRequerida(string value)
            {
                detalleAccionRequerida = value;
            }

            public string getDuracion()
            {
                return duracion;
            }

            public void setDuracion(string value)
            {
                duracion = value;
            }

            public string getEncuestaEnviada()
            {
                return encuestaEnviada;
            }

            public void setEncuestaEnviada(string value)
            {
                encuestaEnviada = value;
            }

            public string getObservacionAuditor()
            {
                return observacionAuditor;
            }

            public void setObservacionAuditor(string value)
            {
                observacionAuditor = value;
            }

            public List<RespuestaCliente> getRespuestasDeEncuesta()
            {
                return respuestasDeEncuesta;
            }

            public void setRespuestasDeEncuesta(List<RespuestaCliente> value)
            {
                respuestasDeEncuesta = value;
            }

            public List<CambioEstado> getCambioDeEstado()
            {
                return cambioDeEstado;
            }

            public void setCambioDeEstado(List<CambioEstado> value)
            {
                cambioDeEstado = value;
            }

            public Cliente getCliente()
            {
                return cliente;
            }
        public string getNombreCliente()
        {
            return cliente.getNombreCompleto();
        }
        public void setCliente(Cliente value)
            {
                cliente = value;
            }

        public List<string> GetRespuestas()
        {
            List<string> arrayDescripcionesRta = new List<string>();

            foreach (RespuestaCliente respuesta in respuestasDeEncuesta)
            {
                arrayDescripcionesRta.Add(respuesta.getDescripcionRespuestaSeleccionada());
            }

            return arrayDescripcionesRta;
        }


    public string DescripcionOperador => descripcionOperador;
        public string DeterminarUltimoEstado
        {
            get
            {
                CambioEstado estadoFinal = null;

                foreach (CambioEstado cambioEstado in cambioDeEstado)
                {
                    if (estadoFinal == null || estadoFinal.getFechaHoraInicio() <= cambioEstado.getFechaHoraInicio())
                    {
                        estadoFinal = cambioEstado;
                    }
                }

                if (estadoFinal != null)
                {
                    return estadoFinal.getEstado().ToString();
                }

                return string.Empty; // Devuelve una cadena vacía en lugar de null si no se encuentra ningún estado.
            }
        }



    public string DeterminarFechaHoraUltimoEstado => cambioDeEstado.LastOrDefault().getFechaHoraInicio().ToString(); // Esta habria q borrar?
        public string DeterminarNombreCliente => cliente.getNombreCompleto(); // Esto creo q deberia ir en cliente, o sea aca deberia ir una funcion 

        public bool ConsultarEncuestaRespondida()
        {
            if (this.respuestasDeEncuesta.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool esDePeriodo(DateTime fechaInicio, DateTime fechaFin) // REVISAR QUE SE CUMPLA EL PARADIGMA
        {
            // busca la menor fecha es decir la fecha de inicio, luego busca la mayor fecha 
            // y se fija que entre dentro del periodo elegido

            DateTime? fechaEstadoInicial = null;
            DateTime? fechaEstadoFinal = null;
           
            foreach (CambioEstado cambioEstado in cambioDeEstado)
            {
                if (fechaEstadoInicial >= cambioEstado.getFechaHoraInicio() || fechaEstadoInicial == null)
                {
                    fechaEstadoInicial = cambioEstado.getFechaHoraInicio();
                }

                if (fechaEstadoFinal <= cambioEstado.getFechaHoraInicio() || fechaEstadoFinal == null)
                {
                    fechaEstadoFinal = cambioEstado.getFechaHoraInicio();
                }
            }

            if (fechaEstadoInicial > fechaInicio && fechaEstadoFinal < fechaFin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //esto no va
        public List<string> seleccionarLlamada()
        {
            Cliente clienteDeLlamada = this.cliente;
            string nombreCliente = clienteDeLlamada.getNombreCompleto().ToString();

            string duracionLlamada = this.getDuracion();

            CambioEstado? estadoFinal = null;
            foreach (CambioEstado cambioEstado in cambioDeEstado) // En estadoFinal va a terminar quedando el ultimo cambio
            {
                if (estadoFinal.getFechaHoraInicio() <= cambioEstado.getFechaHoraInicio() || estadoFinal == null)
                {
                    estadoFinal = cambioEstado;
                }
            }

            string nombreUltimoEstado = estadoFinal.getNombreEstado();

            return new List<string> { nombreCliente, duracionLlamada, nombreUltimoEstado };
        }
    }
}
