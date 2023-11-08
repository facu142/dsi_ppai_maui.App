using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Estado
    {
        private string nombre;

        public Estado(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string value)
        {
            nombre = value;
        }

        public bool Esfinalizada()
        {
            return nombre == "Finalizada";
        }

        public bool EsIniciada()
        {
            return nombre == "Iniciada";
        }
        public bool EsEnCurso()
        {
            return nombre == "EnCurso";
        }
        public bool EsDescartada()
        {
            return nombre == "Descartada";
        }
        public bool EsCancelada()
        {
            return nombre == "Cancelada";
        }

    }
}
