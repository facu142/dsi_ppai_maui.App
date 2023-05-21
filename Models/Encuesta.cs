using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Encuesta
    {
        string Descripcion { get; set; }
        DateTime FechaFinVigencia { get; set; }
        List<Pregunta> Preguntas { get; set; }

        public Encuesta()
        {
            Preguntas = new List<Pregunta>();
        }
    }
}
