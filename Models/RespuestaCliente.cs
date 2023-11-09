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

        public RespuestaCliente(DateTime fechaEncuesta, RespuestaPosible respuestaSeleccionada)
        {
            this.fechaEncuesta = fechaEncuesta;
            this.respuestaSeleccionada = respuestaSeleccionada;
        }

        public DateTime getFechaEncuesta()
        {
            return fechaEncuesta;
        }

        public void setFechaEncuesta(DateTime value)
        {
            fechaEncuesta = value;
        }

        public RespuestaPosible getRespuestaSeleccionada()
        {
            return respuestaSeleccionada;
        }
        public string getDescripcionRespuestaSeleccionada()
        {
            return respuestaSeleccionada.getDescripcion();
        }

        public void setRespuestaSeleccionada(RespuestaPosible value)
        {
            respuestaSeleccionada = value;
        }
    }
}
