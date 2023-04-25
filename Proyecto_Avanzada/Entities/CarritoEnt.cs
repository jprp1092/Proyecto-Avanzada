using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Avanzada.Entities
{
    public class CarritoEnt
    {
        public int CantidadNoches { get; set; }
        public double MontoCarrito { get; set; }
    }
    public class CarritoDetalleEnt
    {
        public string NombreHospedaje { get; set; }
        public int CantidadNoches { get; set; }
        public double Precio { get; set; }
        public double SubTotal { get; set; }
        public double? Impuesto { get; set; }
        public double? Total { get; set; }
    }
}