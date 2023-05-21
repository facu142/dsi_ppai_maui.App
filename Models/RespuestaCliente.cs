using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class RespuestaCliente
    {
        public DateTime FechaEncuesta { get; set; }
        public RespuestaPosible RespuestaSeleccionada { get; set; }
    }
}
