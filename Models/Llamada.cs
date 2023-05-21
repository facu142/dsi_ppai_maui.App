using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Llamada
    {
        string DescripcionOperador { get; set; }
        string DetalleAccionRequerida { get; set; }
        string Duracion { get; set; }
        string EncuestaEnviada { get; set; }
        string ObservacionAuditor { get; set; }

        List<RespuestaCliente> RespuestasDeEncuesta { get; set; }

        public Llamada()
        {
            RespuestasDeEncuesta = new List<RespuestaCliente>();
        }
    }

}
