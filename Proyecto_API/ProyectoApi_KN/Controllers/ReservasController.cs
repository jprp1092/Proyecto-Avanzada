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
    public class ReservasController : ApiController
    {
        ReservasModel model = new ReservasModel();

        [HttpPost]
        [Authorize]
        [Route("api/CrearReserva")]
        public void CrearReserva(ReservasEnt entidad)
        {
            model.CrearReserva(entidad);
        }

        [HttpGet]
        [Authorize]
        [Route("api/ConsultarReservas")]
        public List<ReservasEnt> ConsultarReservas()
        {
            return model.ConsultarReservas();
        }

        [HttpGet]
        [Authorize]
        [Route("api/ConsultarReserva")]
        public ReservasEnt ConsultarReserva(long q)
        {
            return model.ConsultarReserva(q);
        }


    }
}
