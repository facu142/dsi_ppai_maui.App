using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class RespuestaCliente
    {
        private DateTime fechaEncuesta;
        private RespuestaPosible respuestaSeleccionada;


        public DateTime FechaEncuesta
        {
            get {  return fechaEncuesta;}
            set { fechaEncuesta = value;}
        }

        public RespuestaPosible RespuestaSeleccionada
        {
            get { return respuestaSeleccionada; }
            set { respuestaSeleccionada = value; }
        }
    }
}
