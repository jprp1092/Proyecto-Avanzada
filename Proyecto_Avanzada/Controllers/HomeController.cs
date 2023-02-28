using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Avanzada.Controllers
{
    public class HomeController : Controller
    {
        UsuarioModel model = new UsuarioModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioEnt entidad)
        {
            try
            {
                var resultado = model.ValidarUsuario(entidad);
                if (resultado != null)
                {
                    Session["CodigoUsuario"] = resultado.ConsecutivoUsuario;
                    Session["CorreoUsuario"] = resultado.CorreoElectronico;
                    return View("About");
                }
                else
                {
                    ViewBag.mensajeError = "Sus credenciales son incorrectas";
                    return View();
                }
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora("Home-Principal", ex.Message);
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
                return View("Index");
            }
        }


        //Método de Registrar Usuario

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora("Home-RegistrarUsuario", ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult BuscarCorreo(string correo)
        {
            try
            {
                var resultado = model.BuscarCorreo(correo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora("Home-BuscarCorreo", ex.Message);
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioEnt entidad)
        {
            try
            {
                model.RegistrarUsuario(entidad);
                return View("Index");
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora("Home-RegistrarUsuario", ex.Message);
                return View("Index");
            }
        }



        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Packages()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}