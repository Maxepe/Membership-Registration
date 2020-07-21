using Parcial2_PROGIII_110925.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial2_PROGIII_110925.ViewModels.Reportes
{
    public class ReporteItemVM
    {
        public List<DeporteItemVM> listaDeportes { set; get; }

        public ReporteItemVM()
        {
            listaDeportes = new List<DeporteItemVM>();
            cargarVariables();
        }
        public void cargarVariables()
        {
            listaDeportes = AccDatosSocio.ObtenerCantPorDeporte();
        }
    }
}