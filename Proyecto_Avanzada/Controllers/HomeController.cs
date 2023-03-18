using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.Models;
using System;
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
        UsuarioModel usuariosModel = new UsuarioModel();
        ProvinciaModel provinciasModel = new ProvinciaModel();
        LogsModel logsModel = new LogsModel();

        //Método de Iniciar Sesión

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

        

        [HttpPost]
        public ActionResult BuscarCorreo(string correo)
        {
            try
            {
                var resultado = usuariosModel.BuscarCorreo(correo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }

        //Método de Registrar Usuario

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            try
            {
                ViewBag.ListaProvincias = provinciasModel.ConsultarProvincias();
                ViewBag.ListaRoles = provinciasModel.ConsultarRoles();
                return View();
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioEnt entidad)
        {
            try
            {

                var resultado = usuariosModel.RegistrarUsuario(entidad);

                return View(entidad);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarBitacora(ControllerContext, ex.Message);
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