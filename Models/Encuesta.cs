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

        private static List<Encuesta> ObtenerTodasLasEncuestas()
        {
            Encuesta Encuesta1 = new() { Descripcion = "Conteste ésta encuesta...", FechaFinVigencia = DateTime.Now };
            Encuesta Encuesta2 = new() { Descripcion = "Conteste ésta encuesta...", FechaFinVigencia = DateTime.Now };
            Encuesta Encuesta3 = new() { Descripcion = "Conteste ésta encuesta...", FechaFinVigencia = DateTime.Now };
            List<Encuesta> todasLasEncuestas = new List<Encuesta>();

            todasLasEncuestas.Add(Encuesta1);
            todasLasEncuestas.Add(Encuesta2);
            todasLasEncuestas.Add(Encuesta3);

            return todasLasEncuestas;
        }

        public Encuesta esEncuestaLlamada(Llamada llamadaSeleccionada)
        {

            if (this.Cliente.NombreCompleto == llamadaSeleccionada.Cliente.NombreCompleto)
            {
                bool encuestaCoincide = true;


                for (int nro = 0; nro < this.Preguntas.Count; nro++)
                {
                    List<string> respuestasPosibles = this.Preguntas[nro].Respuestas.Select(respuesta => respuesta.Valor).ToList();
                    string respuestaSeleccionada = llamadaSeleccionada.RespuestasDeEncuesta[nro].RespuestaSeleccionada?.Valor;

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
