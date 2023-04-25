using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi_KN.Models
{
    public class FacturasModel
    {
        public void ConfirmarPago(FacturasEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                conexion.ConfirmarPago(entidad.ConsecutivoUsuario);
            }
        }

        public List<FacturasEnt> MostrarFacturas(long ConsecutivoUsuario)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = conexion.MostrarFacturas(ConsecutivoUsuario).ToList();

                List<FacturasEnt> facturas = new List<FacturasEnt>();
                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        facturas.Add(new FacturasEnt
                        {
                            IdMaestro = item.IdMaestro,
                            FechaCompra = item.FechaCompra,
                            SubTotal = item.SubTotal,
                            Impuesto = item.Impuestos,
                            Total = item.Total
                        });
                    }
                }

                return facturas;
            }
        }
    }
}