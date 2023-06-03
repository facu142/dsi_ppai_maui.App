using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<Encuesta> esEncuestaDelCliente(string nombreCliente)
            {
                // lógica para obtener las encuestas del cliente

                //lista de todas las encuestas disponibles
                List<Encuesta> todasLasEncuestas = ObtenerTodasLasEncuestas();

                // Filtras las encuestas por el nombre del cliente
                List<Encuesta> encuestasDelCliente = todasLasEncuestas.Where(encuesta => encuesta.Cliente.NombreCompleto == nombreCliente).ToList();

                return encuestasDelCliente;
            }

            private static List<Encuesta> ObtenerTodasLasEncuestas()
            {
                // Implementación para obtener todas las encuestas disponibles
           
                List<Encuesta> todasLasEncuestas = new List<Encuesta>();

                // Agregar encuestas a la lista...

                return todasLasEncuestas;
            }
        }

    }
