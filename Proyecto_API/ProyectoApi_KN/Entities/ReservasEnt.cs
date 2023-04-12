using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi_KN.Entities
{
    
    public class ReservasEnt
    {
        public long ConsecutivoReservas { get; set; }
        public DateTime FechaReserva { get; set; }
        public long CodUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public long CodDestino { get; set; }
        public bool Pago { get; set; }
        public bool Estado { get; set; }

    }

}