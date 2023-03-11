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
    /*
       F10 = Avanzamos línea por línea
       F11 = Ingresamos a los métodos
       F5 = Liberamos la depuración
    */
    public class HomeController : Controller
    {
        UsuarioModel model = new UsuarioModel();

        //Método de Iniciar Sesión

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora("Home-Index", ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Principal(UsuarioEnt entidad)
        {
            try
            {
                var resultado = model.ValidarUsuario(entidad);
                if (resultado != null)
                {
                    Session["CodigoUsuario"] = resultado.ConsecutivoUsuario;
                    Session["CorreoUsuario"] = resultado.CorreoElectronico;
                    Session["TokenUsuario"] = resultado.Token;
                    return View();
                }
                else
                {
                    ViewBag.mensajeError = "Sus credenciales son incorrectas";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora("Home-Principal", ex.Message);
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
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

        //Método de Registrar Usuario

        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioEnt entidad)
        {
            try
            {
                var respuesta = model.RegistrarUsuario(entidad);

                if (respuesta > 0)
                    return View("Index");
                else
                {
                    ViewBag.mensajeError = "El usuario no se pudo registrar";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora("Home-RegistrarUsuario", ex.Message);
                return View("Index");
            }
        }

        //Método de Recuperar Contraseña

        [HttpGet]
        public ActionResult RecuperarContrasenna()
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
        public ActionResult RecuperarContrasenna(UsuarioEnt entidad)
        {
            try
            {
                model.RecuperarContrasenna(entidad);
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