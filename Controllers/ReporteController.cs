using Parcial2_PROGIII_110925.ViewModels.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial2_PROGIII_110925.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Reporte()
        {
            ReporteItemVM resultado = new ReporteItemVM();
            return View(resultado);
        }
    }
}