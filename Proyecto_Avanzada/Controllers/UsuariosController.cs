using Proyecto_Avanzada.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Proyecto_Avanzada.Controllers
{
    [SessionFilter]
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
                var resultado = usuariosModel.ConsultarUsuarios().FirstOrDefault(x => x.ConsecutivoUsuario == q);

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

    }
}