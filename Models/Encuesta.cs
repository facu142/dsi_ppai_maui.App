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
        private Cliente cliente; // new

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

        public Cliente Cliente
        { 
            get { return cliente; }
            set { cliente = value; } // ??
        }

        public bool esEncuestaDeCliente(string nombreDeCliente)
        {
            if (this.Cliente.NombreCompleto == nombreDeCliente)
            {
                return true;
            }
            else { return false; }
        }
    }
}
