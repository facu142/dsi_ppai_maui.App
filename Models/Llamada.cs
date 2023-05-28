﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dsi_ppai_maui.Models
{
    public class Llamada
    {
        private string descripcionOperador;
        private string detalleAccionRequerida;
        private string duracion;
        private string encuestaEnviada;
        private string observacionAuditor;
        private List<RespuestaCliente> respuestasDeEncuesta;
        private List<CambioEstado> cambioDeEstado;
        private Cliente cliente;


        public string DescripcionOperador 
        {
            get {  return descripcionOperador; }
            set { descripcionOperador = value; }
        }

        public string DetalleAccionRequerida
        {
            get { return detalleAccionRequerida; }
            set { detalleAccionRequerida = value; }
        }

        public string Duracion
        {
            get { return duracion; }
            set { duracion = value;}
        }

        public string EncuestaEnviada
        {
            get { return encuestaEnviada; }
            set { encuestaEnviada = value; }
        }

        public string ObservacionAuditor
        {
            get { return observacionAuditor;}
            set { observacionAuditor = value;}
        }

        public List<RespuestaCliente> RespuestasDeEncuesta
        {
            get { return respuestasDeEncuesta;}
            set { respuestasDeEncuesta = value;}
        }

        public List<CambioEstado> CambioDeEstado
        {
            get { return cambioDeEstado; }
            set { cambioDeEstado = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }


        //public string DeterminarUltimoEstado()
        //{
        //    CambioEstado estadoFinal = new();

        //    foreach (CambioEstado cambioEstado in CambioDeEstado) // En estadoFinal va a terminar quedando el ultimo cambio
        //    {
        //        if (estadoFinal.FechaHoraInicio <= cambioEstado.FechaHoraInicio || estadoFinal == null)
        //        {
        //            estadoFinal = cambioEstado;
        //        }
        //    }

        //    string nombreUltimoEstado = estadoFinal.getEstado().ToString();

        //    return nombreUltimoEstado;

        //}

        public string DeterminarUltimoEstado
        {
            get
            {
                CambioEstado estadoFinal = null;

                foreach (CambioEstado cambioEstado in CambioDeEstado)
                {
                    if (estadoFinal == null || estadoFinal.FechaHoraInicio <= cambioEstado.FechaHoraInicio)
                    {
                        estadoFinal = cambioEstado;
                    }
                }

                if (estadoFinal != null)
                {
                    return estadoFinal.getEstado().ToString();
                }

                return null; // Devuelve null si no se encuentra ningún estado
            }
        }

        public string DeterminarFechaHoraUltimoEstado => cambioDeEstado.LastOrDefault().FechaHoraInicio.ToString(); // Esta habria q borrar?
        public string DeterminarNombreCliente => Cliente.NombreCompleto; // Esto creo q deberia ir en cliente, o sea aca deberia ir una funcion 
        public Llamada()
        {
            respuestasDeEncuesta = new List<RespuestaCliente>();
        }

        public bool consultarEncuestaRespondida()
        {
            if (this.RespuestasDeEncuesta.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool esDePeriodo(DateTime fechaInicio, DateTime fechaFin) // REVISAR QUE SE CUMPLA EL PARADIGMA
        {
            // busca la menor fecha es decir la fecha de inicio, luego busca la mayor fecha 
            // y se fija que entre dentro del periodo elegido

            DateTime? fechaEstadoInicial = null;
            DateTime? fechaEstadoFinal = null;

            foreach (CambioEstado cambioEstado in CambioDeEstado)
            {
                if (fechaEstadoInicial >= cambioEstado.FechaHoraInicio || fechaEstadoInicial == null)
                {
                    fechaEstadoInicial = cambioEstado.FechaHoraInicio; 
                }

                if (fechaEstadoFinal <= cambioEstado.FechaHoraInicio || fechaEstadoFinal == null)
                {
                    fechaEstadoFinal = cambioEstado.FechaHoraInicio;
                }
            }

            if (fechaEstadoInicial > fechaInicio && fechaEstadoFinal < fechaFin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> seleccionarLlamada()
        {
            Cliente clienteDeLlamada = this.Cliente;
            string nombreCliente = clienteDeLlamada.NombreCompleto.ToString();

            string duracionLlamada = this.Duracion;

            CambioEstado? estadoFinal = null;
            foreach (CambioEstado cambioEstado in CambioDeEstado) // En estadoFinal va a terminar quedando el ultimo cambio
            {
                if (estadoFinal.FechaHoraInicio <= cambioEstado.FechaHoraInicio || estadoFinal == null)
                {
                    estadoFinal = cambioEstado;
                }
            }

            string nombreUltimoEstado = estadoFinal.getEstado();

            return new List<string> { nombreCliente, duracionLlamada, nombreUltimoEstado };
        }
    }
}
