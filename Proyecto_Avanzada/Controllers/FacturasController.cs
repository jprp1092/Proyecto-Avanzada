using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Avanzada.Controllers
{
    public class FacturasController : Controller
    {
        FacturasModel facturasModel = new FacturasModel();
        ReservasModel reservasModel = new ReservasModel();

        [HttpPost]
        public ActionResult ConfirmarPago()
        {
            facturasModel.ConfirmarPago();

            var datosCarritoTemporal = reservasModel.MostrarCarritoTemporal();
            Session["CantidadCarritoTemporal"] = datosCarritoTemporal.CantidadNoches;
            Session["MontoCarritoTemporal"] = datosCarritoTemporal.MontoCarrito;
            
            return RedirectToAction("MostrarFacturas", "Facturas");


        }

        [HttpGet]
        public ActionResult MostrarFacturas()
        {
            var datos = facturasModel.MostrarFacturas();
            return View(datos);
        }

    }
}