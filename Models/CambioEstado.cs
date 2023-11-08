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
        public CambioEstado( Estado estado, DateTime fechaHoraInicio)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.estado = estado;
        }

        public DateTime getFechaHoraInicio()
        {
            return fechaHoraInicio;
        }

        public void setFechaHoraInicio(DateTime valor)
        {
            fechaHoraInicio = valor;
        }

        public Estado getEstado()
        {
            return estado;
        }

        public void setEstado(Estado valor)
        {
            estado = valor;
        }

        public string getNombreEstado()
        {
            return estado.getNombre();
        }
    }

}