using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class CambioEstado
    {
        private DateTime fechaHoraInicio;
        private Estado estado;

        public DateTime FechaHoraInicio
        {
            get { return fechaHoraInicio; }
            set { fechaHoraInicio = value; }
        }

        public Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string getEstadoNombre()
        {
            return this.Estado.Nombre;
        }

    }
}