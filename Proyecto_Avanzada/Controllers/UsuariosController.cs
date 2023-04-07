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
    [SessionFilter]
    [AdminFilter]
    public class UsuariosController : Controller
    {
        UsuarioModel usuariosModel = new UsuarioModel();
        ProvinciaModel provinciasModel = new ProvinciaModel();
        LogsModel logsModel = new LogsModel();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var resultado = usuariosModel.ConsultarUsuarios();
                return View(resultado);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuario(long q)
        {
            try
            {
                var resultado = usuariosModel.ConsultarUsuario(q);

                ViewBag.ListaProvincias = provinciasModel.ConsultarProvincias();
                ViewBag.ListaRoles = provinciasModel.ConsultarRoles();

                return View(resultado);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(UsuarioEnt entidad)
        {
            try
            {
                usuariosModel.ActualizarUsuario(entidad);
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(long q)
        {
            usuariosModel.CambiarEstado(q);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

    }
}