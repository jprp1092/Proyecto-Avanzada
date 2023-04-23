using Proyecto_Avanzada.App_Start;
using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoWeb_KN.Controllers
{

    [OutputCache(NoStore = true, Duration = 0 )]
    /*
       F10 = Avanzamos lÃ­nea por lÃ­nea
       F11 = Ingresamos a los mÃ©todos
       F5 = Liberamos la depuraciÃ³n
    */

    public class HomeController : Controller
    {
        UsuarioModel usuariosModel = new UsuarioModel();
        ProvinciaModel provinciasModel = new ProvinciaModel();
        LogsModel logsModel = new LogsModel();
        ContactModel contactModel = new ContactModel();
        HospedajeModel hospedajeModel = new HospedajeModel();
        //MÃ©todo de Iniciar SesiÃ³n

        [HttpGet]
        public ActionResult Index()
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
                    Session["Rol"] = resultado.Rol;
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
               // ViewBag.ListaProvincias = provinciasModel.ConsultarProvincias();
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

                return View("Index");
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


        [HttpGet]
        public ActionResult Packages()
        {
            try
            {

                var datos = hospedajeModel.ConsultarHospedaje();

                return View("Packages",datos);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
                return View("Index");
            }

        }

        [HttpPost]
        public ActionResult Packages(string date1, string date2)
        {
            try
            {
                var datos = hospedajeModel.ConsultarHospedaje();
                ViewBag.Fecha1 = date1;
                ViewBag.Fecha2 = date2;
                DateTime fecha1 = DateTime.ParseExact(date1, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime fecha2 = DateTime.ParseExact(date2, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                TimeSpan duracion = fecha2 - fecha1;
                int noches = (int)duracion.TotalDays;

                ViewBag.Noches = noches;

                return View(datos);

            }
            catch (Exception ex)
            {

                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Contact()
        {
            try
            {
                return View();

            }
            
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
                return View("Index");
            }
        }


        [HttpPost]
        public ActionResult EnvioCorreoContacto(CorreoEnt mensaje)
        {
            try
            {
                contactModel.EnvioCorreoContacto(mensaje);
                contactModel.RegistrarCorreoContacto(mensaje);

                return RedirectToAction("Contact", "Home");

            }

            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                ViewBag.mensajeError = "Sus credenciales no fueron validadas";
                return View("Index");
            }
        }


        [HttpGet]
        public ActionResult Login()
        {
            try
            {
                Session.Clear();
                ViewBag.ListaProvincias = provinciasModel.ConsultarProvincias();
                return View();
            }
            catch (Exception)
            {

                return View("Index");
            }
        }

    }

}
