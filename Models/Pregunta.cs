using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Pregunta
    {
        public string StrPregunta { get; set; }
        public List<RespuestaPosible> Respuestas { get; set; }
        public Encuesta Encuesta { get; set; } // dependencia
        public Pregunta()
        {
            Respuestas = new List<RespuestaPosible>();
        }
    }
}
