using Parcial2_PROGIII_110925.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial2_PROGIII_110925.ViewModels
{
    public class DeporteItemVM
    {
        //public int pIdDeporte { set; get; }
        //public string pNombre { set; get; }
        //public int pCantidad { set; get; }

        private int idDeporte;
        private string nombre;
        private int cantidad;

        public int pIdDeporte
        {
            set { idDeporte = value; }
            get { return idDeporte; }
        }
        public string pNombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public int pCantidad
        {
            set { cantidad = value; }
            get { return cantidad; }
        }

    }
}