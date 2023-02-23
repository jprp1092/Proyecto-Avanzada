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
    /*
        httpPost --> Body
        httpPut --> Body
        httpDelete --> Url
        httpGet --> Url
    */
    public class UsuariosController : ApiController
    {
        UsuarioModel model = new UsuarioModel();

        [HttpPost]
        [Route("api/ValidarUsuario")]
        public UsuarioEnt ValidarUsuario(UsuarioEnt entidad)
        {
            return model.ValidarUsuario(entidad);
        }

        [HttpGet]
        [Route("api/ConsultarUsuarios")]
        public List<UsuarioEnt> ConsultarUsuarios()
        {
            return model.ConsultarUsuarios();
        }

        [HttpGet]
        [Route("api/BuscarCorreo")]
        public string BuscarCorreo(string correoElectronico)
        {
            return model.BuscarCorreo(correoElectronico);
        }

        [HttpPost]
        [Route("api/RegistrarUsuario")]
        public int RegistrarUsuario(UsuarioEnt entidad)
        {
            return model.RegistrarUsuario(entidad);
        }

    }
}
