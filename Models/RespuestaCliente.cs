using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class RespuestaCliente
    {
        DateTime FechaEncuesta { get; set; }

        RespuestaPosible RespuestaSeleccionada { get; set; }
    }
}
