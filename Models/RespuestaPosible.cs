using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class RespuestaPosible
    {
        private string descripcion;
        private string valor;

        public string Descripcion
        { 
            get { return descripcion; } 
            set {  descripcion = value; } 
        }

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

    }
}
