using ProyectoApi_KN.Entities;
using ProyectoApi_KN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;



namespace ProyectoApi_KN.Controllers
{
    public class ProvinciaController : ApiController
    {
        ProvinciaModel model = new ProvinciaModel();

        [HttpGet]
        //[Authorize]
        [Route("api/ConsultarProvincias")]
        public List<ProvinciaEnt> ConsultarProvincias()
        {
            return model.ConsultarProvincias();
        }

    }
}