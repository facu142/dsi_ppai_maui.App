using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Llamada
    {
        public string DescripcionOperador { get; set; }
        public string DetalleAccionRequerida { get; set; }
        public string Duracion { get; set; }
        public string EncuestaEnviada { get; set; }
        public string ObservacionAuditor { get; set; }

        public List<RespuestaCliente> RespuestasDeEncuesta { get; set; }

        public List<CambioEstado> CambioDeEstado {get; set;}
        public string DeterminarUltimoEstado => CambioDeEstado.LastOrDefault()?.Estado?.Nombre;

        public Llamada()
        {
            RespuestasDeEncuesta = new List<RespuestaCliente>();
        }

    }

}
