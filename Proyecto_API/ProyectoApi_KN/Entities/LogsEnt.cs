using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

