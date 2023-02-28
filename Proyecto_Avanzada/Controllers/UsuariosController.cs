using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Avanzada.Controllers
{
    public class UsuariosController : Controller
    {
        UsuarioModel model = new UsuarioModel();

        // GET: Usuarios
        public ActionResult Index()
        {
            try
            {
                var resultado = model.ConsultarUsuarios();
                return View(resultado);
            }
            catch (Exception ex)
            {
                model.RegistrarErrores(Session["CodigoUsuario"], "Usuarios-Index", ex.Message);
                return View("Index");
            }
        }
    }
}