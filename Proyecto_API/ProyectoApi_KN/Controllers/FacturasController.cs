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
    public class FacturasController : ApiController
    {
        FacturasModel model = new FacturasModel();


        [HttpPost]
        [Route("api/ConfirmarPago")]
        public void ConfirmarPago(FacturasEnt entidad)
        {
            model.ConfirmarPago(entidad);
        }
    
        
        [HttpGet]
        [Route("api/MostrarFacturas")]
        public List<FacturasEnt> MostrarFacturas(long ConsecutivoUsuario)
        {
            return model.MostrarFacturas(ConsecutivoUsuario);
        }
    }
}
