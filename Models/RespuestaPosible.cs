using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class RespuestaPosible
    {
        private string descripcion;
        private string valor;
        private Pregunta pregunta; // Dependencia

        public RespuestaPosible(string descripcion, string valor)
        {
            this.descripcion = descripcion;
            this.valor = valor;
        }

        public string getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(string value)
        {
            descripcion = value;
        }

        public string getValor()
        {
            return valor;
        }

        public void setValor(string value)
        {
            valor = value;
        }

        public Pregunta getPregunta()
        {
            return pregunta;
        }

        public void setPregunta(Pregunta value)
        {
            pregunta = value;
        }
    }
}
