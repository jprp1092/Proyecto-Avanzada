using Proyecto_Avanzada.App_Start;
using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Avanzada.Controllers
{
    [AfliliadoFilter]
    [OutputCache(NoStore = true, Duration = 0)]
    public class HospedajeController : Controller
    {
        LogsModel logsModel = new LogsModel();
        ProvinciaModel provinciasModel = new ProvinciaModel();
        HospedajeModel hospedajeModel = new HospedajeModel();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                ViewBag.ListaProvincias = provinciasModel.ConsultarProvincias();
                return View();
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult RegistrarHospedaje()
        {
            try
            {
                ViewBag.ListaProvincias = provinciasModel.ConsultarProvincias();
                return View();
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }


        [HttpPost]
        public ActionResult RegistrarHospedaje(HospedajeEnt entidad)
        {
            try
            {
                ViewBag.ListaProvincias = provinciasModel.ConsultarProvincias();

                var respuesta = hospedajeModel.RegistrarHospedaje(entidad);

                if (respuesta > 0)
                    return View("Index");
                else
                {
                    ViewBag.mensajeError = "El hospedaje no se pudo registrar";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }
    }
}