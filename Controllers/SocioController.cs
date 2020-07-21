using Parcial2_PROGIII_110925.AccesoDatos;
using Parcial2_PROGIII_110925.Models;
using Parcial2_PROGIII_110925.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial2_PROGIII_110925.Controllers
{
    public class SocioController : Controller
    {
        // GET: Socio
        public ActionResult NuevoSocio()
        {
            List<TipoDocItemVM> tiposDoc = AccDatosSocio.ObtenerTiposDoc();
            List<SelectListItem> items = tiposDoc.ConvertAll(x =>
            {
                return new SelectListItem
                {
                    Text = x.pNombre,
                    Value = x.pIdTipoDoc.ToString(),
                    Selected = false
                };
            });

            List<DeporteItemVM> deportes = AccDatosSocio.ObtenerDeportes();
            List<SelectListItem> itemsDeporte = deportes.ConvertAll(z =>
            {
                return new SelectListItem
                {
                    Text = z.pNombre,
                    Value = z.pIdDeporte.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            ViewBag.itemsdeporte = itemsDeporte;

            return View();
        }

        [HttpPost]
        public ActionResult NuevoSocio(Socio modelo)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AccDatosSocio.InsertarSocio(modelo);
                if (resultado)
                {
                    return RedirectToAction("ListadoSocios", "Socio");
                }
                else
                {
                    return View(modelo);
                }
            }
            return View(modelo);
        }

        public ActionResult ListadoSocios()
        {
            List<Socio> listaSocios = AccDatosSocio.ObtenerListaSocio();
            return View(listaSocios);
        }
    }
}