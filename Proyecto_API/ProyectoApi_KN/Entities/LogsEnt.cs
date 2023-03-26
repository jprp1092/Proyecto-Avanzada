using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProyectoApi_KN.Entities
{
    public class LogsEnt
{
    public long ConsecutivoUsuario { get; set; }
    public string Origen { get; set; }
    public DateTime FechaHora { get; set; }
    public string DescripcionError { get; set; }
}
}

