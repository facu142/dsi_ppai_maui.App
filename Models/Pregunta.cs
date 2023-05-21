using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Pregunta
    {
        string StrPregunta { get; set; }
        List<RespuestaPosible> Respuestas { get; set; }
        public Pregunta()
        {
            Respuestas = new List<RespuestaPosible>();
        }
    }
}
