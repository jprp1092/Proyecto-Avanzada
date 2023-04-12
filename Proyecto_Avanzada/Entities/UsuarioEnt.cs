﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Avanzada.Entities
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
        public short CodProvincia { get; set; }
        public short Telefono { get; set; }
        public string Rol { get; set; }
    }
}
