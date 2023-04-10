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
        ContactModel contact = new ContactModel();
        UsuarioModel model = new UsuarioModel();

        [HttpPost]
        [AllowAnonymous]
        [Route("api/ValidarUsuario")]
        public UsuarioEnt ValidarUsuario(UsuarioEnt entidad)
        {
            return model.ValidarUsuario(entidad);
        }

        [HttpGet]
        [Authorize]
        [Route("api/ConsultarUsuarios")]
        public List<UsuarioEnt> ConsultarUsuarios()
        {
            return model.ConsultarUsuarios();
        }

        [HttpGet]
        [Authorize]
        [Route("api/ConsultarUsuario")]
        public UsuarioEnt ConsultarUsuario(long q)
        {
            return model.ConsultarUsuario(q);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/BuscarCorreo")]
        public string BuscarCorreo(string correoElectronico)
        {
            return model.BuscarCorreo(correoElectronico);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RegistrarUsuario")]
        public int RegistrarUsuario(UsuarioEnt entidad)
        {
            return model.RegistrarUsuario(entidad);
        }

        [HttpPut]
        [Authorize]
        [Route("api/ActualizarUsuario")]
        public void ActualizarUsuario(UsuarioEnt entidad)
        {
            model.ActualizarUsuario(entidad);
        }

        [HttpDelete]
        [Authorize]
        [Route("api/CambiarEstado")]
        public void CambiarEstado(long q)
        {
            model.CambiarEstado(q);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RecuperarContrasenna")]
        public void RecuperarContrasenna(UsuarioEnt entidad)
        {
            model.RecuperarContrasenna(entidad);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/EnvioCorreoContacto")]
        public void EnvioCorreoContacto(CorreoEnt mensaje)
        {
            contact.EnviarCorreoContacto(mensaje);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RegistrarCorreoContacto")]
        public void RegistrarCorreoContacto(CorreoEnt mensaje)
        {
            contact.RegistrarCorreoContacto(mensaje);
        }


    }
}


