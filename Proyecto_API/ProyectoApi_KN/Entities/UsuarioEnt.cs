using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi_KN.Entities
{
    public class UsuarioEnt
    {
        public long ConsecutivoUsuario { get; set; }
        public string CorreoElectronico { get; set; }

        public string Contrasenna { get; set; }
        public bool Estado { get; set; }
        public string Token { get; set; }

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public byte CodProvincia { get; set; }
        public string Rol { get; set; }
    }

}