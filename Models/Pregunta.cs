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
        private Encuesta encuesta; // dependencia  NO VA ESTO
        
        
        public string StrPregunta
        {
            get { return strPregunta; }
            set { strPregunta = value; }
        }

        public List<RespuestaPosible> Respuestas
        { 
            get { return respuestas; } 
            set { respuestas = value; }
        }

        public Encuesta Encuesta
        {
            get { return encuesta; }
            set { encuesta = value; }
        }

        public Pregunta()
        {
            Respuestas = new List<RespuestaPosible>();
        }
    }
}
