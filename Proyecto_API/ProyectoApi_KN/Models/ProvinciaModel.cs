using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModeloBD;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace ProyectoApi_KN.Models
{
    public class ProvinciaModel
{

    public List<ProvinciaEnt> ConsultarProvincias()
    {
        using (var conexion = new ProyectoW_BDEntities())
        {
            var datos = (from x in conexion.PROVINCIAS
                         select x).ToList();

            List<ProvinciaEnt> listaEntidadResultado = new List<ProvinciaEnt>();
            foreach (var item in datos)
            {
                listaEntidadResultado.Add(new ProvinciaEnt
                {
                    CodProvincia = item.CodProvincia,
                    NombreProvincia = item.NombreProvincia
                });
            }

            return listaEntidadResultado;
        }
    }

}
}
