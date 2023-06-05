using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Encuesta
    {
        private string descripcion;
        private DateTime fechaFinVigencia;
        private List<Pregunta> preguntas;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DateTime FechaFinVigencia
        {
            get { return fechaFinVigencia; }
            set { fechaFinVigencia = value; }
        }

        public List<Pregunta> Preguntas
        {
            get { return preguntas; }
            set { preguntas = value; }
        }

        public Cliente Cliente { get; set; }


        public Encuesta esEncuestaLlamada(Llamada llamadaSeleccionada)
        {

            if (this.Cliente.NombreCompleto == llamadaSeleccionada.Cliente.NombreCompleto)
            {
                bool encuestaCoincide = true;

                List<Pregunta> PreguntasEncuesta = this.Preguntas;
                List<RespuestaCliente> respuestasEncuesta = llamadaSeleccionada.RespuestasDeEncuesta;
                
                for (int nro = 0; nro < PreguntasEncuesta.Count; nro++)
                {
                    List<string> respuestasPosibles = PreguntasEncuesta[nro].ObtenerRespuestasPosibles();
                    string respuestaSeleccionada = respuestasEncuesta[nro].RespuestaSeleccionada?.Valor;

                    if (respuestaSeleccionada == null || !respuestasPosibles.Contains(respuestaSeleccionada))
                    {
                        encuestaCoincide = false;
                        break;
                    }
                }

                if (encuestaCoincide)
                {
                    return this;
                }

                return null;
            }
            return null;
        }
    }

}
