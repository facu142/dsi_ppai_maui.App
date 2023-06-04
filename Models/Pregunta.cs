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

        public List<string> ObtenerRespuestasPosibles()
        {
            List<string> valoresRespuestas = respuestas.Select(respuesta => respuesta.Valor).ToList();
            return valoresRespuestas;
        }

        public Pregunta()
        {
            Respuestas = new List<RespuestaPosible>();
        }
    }
}
