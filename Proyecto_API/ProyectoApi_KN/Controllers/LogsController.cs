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
    public class LogsController : ApiController
    {
        LogsModel model = new LogsModel();

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RegistrarBitacora")]
        public void RegistrarBitacora(LogsEnt entidad)
        {
            model.RegistrarBitacora(entidad);
        }

        [HttpPost]
        [Authorize]
        [Route("api/RegistrarErrores")]
        public void RegistrarErrores(LogsEnt entidad)
        {
            model.RegistrarErrores(entidad);
        }

    }
}
