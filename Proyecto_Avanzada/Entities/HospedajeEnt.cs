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
    public class HospedajeEnt
    {
        public long ConsecutivoHospedaje { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public float Precio { get; set; }
        public string Disponibilidad { get; set; }
    }

}
