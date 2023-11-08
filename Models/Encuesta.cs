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
        private Cliente cliente;
        public Encuesta(string descripcion, DateTime fechaFinVigencia)
        {
            this.descripcion = descripcion;
            this.fechaFinVigencia = fechaFinVigencia;
        }

        public string getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(string valor)
        {
            descripcion = valor;
        }

        public DateTime getFechaFinVigencia()
        {
            return fechaFinVigencia;
        }

        public void setFechaFinVigencia(DateTime valor)
        {
            fechaFinVigencia = valor;
        }

        public List<Pregunta> getPreguntas()
        {
            return preguntas;
        }

        public void setPreguntas(List<Pregunta> valor)
        {
            preguntas = valor;
        }

        public Cliente getCliente()
        {
            return cliente;
        }

        public void setCliente(Cliente valor)
        {
            cliente = valor;
        }

        public bool esEncuestaDeCliente(string nombreDeCliente)
        {
            if (this.cliente.getNombreCompleto() == nombreDeCliente)
            {
                return true;
            }
            else { return false; }
        }
    }
}
