using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi_KN.Entities
{
    public class CorreoEnt
    {
        public string Emisor { get; set; }
        public string CorreoEmisor { get; set; }
        public string Asunto { get; set; }
        public string CuerpoCorreo { get; set; }

    }
}