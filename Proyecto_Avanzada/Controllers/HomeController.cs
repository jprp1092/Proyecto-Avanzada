using Proyecto_Avanzada.App_Start;
using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoWeb_KN.Controllers
{
    /*
       F10 = Avanzamos lÃ­nea por lÃ­nea
       F11 = Ingresamos a los mÃ©todos
       F5 = Liberamos la depuraciÃ³n
    */

    public class HomeController : Controller
    {
        UsuarioModel usuariosModel = new UsuarioModel();
        ProvinciaModel provinciaModel = new ProvinciaModel();
        LogsModel logsModel = new LogsModel();

        //MÃ©todo de Iniciar SesiÃ³n

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                Session.Clear();
                return View();
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Principal(UsuarioEnt entidad)
        {
            try
            {
                var resultado = usuariosModel.ValidarUsuario(entidad);
                if (resultado != null)
                {
                    Session["CodigoUsuario"] = resultado.ConsecutivoUsuario;
                    Session["CorreoUsuario"] = resultado.CorreoElectronico;
                    Session["Nombre"] = resultado.Nombre;
                    Session["TokenUsuario"] = resultado.Token;
                    return RedirectToAction("PantallaPrincipal", "Home");
                }
                else
                {
                    ViewBag.mensajeError = "Sus credenciales son incorrectas";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
                return View("Index");
            }
        }



        //MÃ©todo de Registrar Usuario

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult BuscarCorreo(string correo)
        {
            var resultado = usuariosModel.BuscarCorreo(correo);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioEnt entidad)
        {
            try
            {
                var respuesta = usuariosModel.RegistrarUsuario(entidad);

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
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }

        //MÃ©todo de Recuperar ContraseÃ±a

        [HttpGet]
        public ActionResult RecuperarContrasenna()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult RecuperarContrasenna(UsuarioEnt entidad)
        {
            try
            {
                usuariosModel.RecuperarContrasenna(entidad);
                return View("Index");
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpGet]
        [SessionFilter]
        public ActionResult PantallaPrincipal()
        {
            try
            {
                return View("Principal");
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
                return View("Index");
            }
        }

        [HttpGet]
        [SessionFilter]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
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

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.ListaProvincias = provinciaModel.ConsultarProvincias();
            ViewBag.ListaRoles = provinciaModel.ConsultarRoles();

            return View();
        }



    }

}
