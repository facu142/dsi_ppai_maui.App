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

        public Cliente(string dni, string nombreCompleto, string nroCelular)
        {
            this.dni = dni;
            this.nombreCompleto = nombreCompleto;
            this.nroCelular = nroCelular;
        }

        public string getDni()
            {
                return dni;
            }

            public void setDni(string value)
            {
                dni = value;
            }

            public string getNombreCompleto()
            {
                return nombreCompleto;
            }

            public void setNombreCompleto(string value)
            {
                nombreCompleto = value;
            }

            public string getNroCelular()
            {
                return nroCelular;
            }

            public void setNroCelular(string value)
            {
                nroCelular = value;
            }
        }

    }
