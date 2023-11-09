using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Pregunta
    {
        private string strPregunta;
        private List<RespuestaPosible> respuestas;
        private Encuesta encuesta; // dependencia

        public Pregunta(string strPregunta, List<RespuestaPosible> respuestas, Encuesta encuesta)
        {
            this.strPregunta = strPregunta;
            this.respuestas = respuestas;
            this.encuesta = encuesta;
        }
        public string getStrPregunta()
        {
            return strPregunta;
        }

        public void setStrPregunta(string value)
        {
            strPregunta = value;
        }

        public List<RespuestaPosible> getRespuestas()
        {
            return respuestas;
        }

        public void setRespuestas(List<RespuestaPosible> value)
        {
            respuestas = value;
        }

        public Encuesta getEncuesta()
        {
            return encuesta;
        }

        public void setEncuesta(Encuesta value)
        {
            encuesta = value;
        }
        public bool EsEncuestaLlamada(List<string> respuestasDeEncuestaCliente)
        {
            foreach (RespuestaPosible respuesta in this.respuestas)
            {
                string descripcion = respuesta.getDescripcion();
                if (respuestasDeEncuestaCliente.Contains(descripcion))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
