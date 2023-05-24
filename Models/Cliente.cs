using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Cliente
    {
        private string dni;
        private string nombreCompleto;
        private string nroCelular;

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public string NroCelular
        {
            get { return nroCelular; }
            set { nroCelular = value;}
        }
    }
}
