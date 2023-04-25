using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi_KN.Entities
{
    public class HospedajeEnt
    {
        public long ConsecutivoHospedaje { get; set; }
        public string Nombre { get; set; }
        public byte CodProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public float Precio { get; set; }
        public string Disponibilidad { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public long ConsecutivoUsuario { get; set; }

    }
}