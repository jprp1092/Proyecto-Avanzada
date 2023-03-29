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
    public class ReservasEnt
    {
        public long ConsecutivoReservas { get; set; }
        public DateTime FechaReserva { get; set; }
        public long CodUsuario { get; set; }
        public long CodDestino { get; set; }
        public bool Pago { get; set; }
        public bool Estado { get; set; }

    }

}
