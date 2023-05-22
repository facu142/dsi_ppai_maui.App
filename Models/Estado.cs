﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsi_ppai_maui.Models
{
    public class Estado
    {
        public string Nombre { get; set; }

        public bool Esfinalizada()
        {
            return Nombre == "Finalizada";
        }

        public bool EsIniciada()
        {
            return Nombre == "Iniciada";
        }
        public bool EsEnCurso()
        {
            return Nombre == "EnCurso";
        }
        public bool EsDescartada()
        {
            return Nombre == "Descartada";
        }
        public bool EsCancelada()
        {
            return Nombre == "Cancelada";
        }

    }
}
