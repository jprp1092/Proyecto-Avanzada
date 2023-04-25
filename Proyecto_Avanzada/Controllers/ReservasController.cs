using Proyecto_Avanzada.App_Start;
using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;



namespace Proyecto_Avanzada.Controllers
{
    [SessionFilter]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ReservasController : Controller
    {
        ReservasModel reservasModel = new ReservasModel();
        LogsModel logsModel = new LogsModel();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var resultado = reservasModel.ConsultarReservas();
                return View(resultado);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Home/Index");
            }
        }
        
        [HttpGet]
        public ActionResult ActualizarReserva(long q)
        {
            try
            {
                var resultado = reservasModel.ConsultarReserva(q);

                //ViewBag.ListaProvincias = reservasModel.ConsultarProvincias(); Posible respuesta para ver el nombre y no el codigo

                return View(resultado);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult ActualizarReserva(ReservasEnt entidad)
        {
            try
            {
                reservasModel.ActualizarReserva(entidad);
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(long id)
        {
            reservasModel.CambiarEstado(id);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarCarrito(long ConsecutivoHospedaje, int CantidadNoches, float precio, string FechaEntrada, string FechaSalida)
        {

            reservasModel.AgregarCarrito(ConsecutivoHospedaje, CantidadNoches, precio, FechaEntrada, FechaSalida);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult VerDesgloceCarrito()
        {
            var datosCarritoTotal = reservasModel.MostrarCarritoTotal();
            return View(datosCarritoTotal);
        }


    }
}