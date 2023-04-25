using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi_KN.Entities
{
    public class FacturasEnt
    {
        public long ConsecutivoUsuario { get; set; }
        public long IdMaestro { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? Total { get; set; }
    }
}