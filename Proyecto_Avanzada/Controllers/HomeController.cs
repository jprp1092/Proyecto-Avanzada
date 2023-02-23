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
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
                return View();
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