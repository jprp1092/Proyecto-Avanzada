using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web;

namespace Proyecto_Avanzada.Entities
{
    public class LogsEnt
    {
        public long ConsecutivoUsuario { get; set; }
        public string Origen { get; set; }
        public DateTime FechaHora { get; set; }
        public string DescripcionError { get; set; }
    }
}

