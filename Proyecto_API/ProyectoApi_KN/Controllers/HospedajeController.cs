using ProyectoApi_KN.Entities;
using ProyectoApi_KN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ProyectoApi_KN.Controllers
{
    public class HospedajeController : ApiController
    {
        HospedajeModel model = new HospedajeModel();

        [HttpPost]
        [Authorize]
        [Route("api/RegistrarHospedaje")]
        public int RegistrarUsuario(HospedajeEnt entidad)
        {
            return model.RegistrarHospedaje(entidad);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ConsultarHospedaje")]
        public List<HospedajeEnt> ConsultarHospedaje()
        {
            return model.ConsultarHospedaje();
        }
    }
}