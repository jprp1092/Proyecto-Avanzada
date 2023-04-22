using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModelDB;
using ProyectoApi_KN.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoApi_KN.Controllers
{
    public class HospedajeController : Controller
    {
        HospedajeModel model = new HospedajeModel();

        [HttpPost]
        [Authorize]
        [Route("api/RegistrarHospedaje")]
        public int RegistrarUsuario(HospedajeEnt entidad)
        {
            return model.RegistrarHospedaje(entidad);
        }
    }
}
