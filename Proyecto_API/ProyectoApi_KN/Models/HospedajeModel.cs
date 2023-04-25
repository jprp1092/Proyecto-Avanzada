using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModelDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProyectoApi_KN.Models
{
    public class HospedajeModel
    {
        public int RegistrarHospedaje(HospedajeEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                HOSPEDAJE hospedaje = new HOSPEDAJE();
                hospedaje.Nombre = entidad.Nombre;
                hospedaje.CodProvincia = entidad.CodProvincia;
                hospedaje.Precio = entidad.Precio;
                hospedaje.Disponibilidad = "Disponible";
                hospedaje.FechaRegistro = DateTime.Now;

                conexion.HOSPEDAJE.Add(hospedaje);
                return conexion.SaveChanges();
            }
        }

        public List<HospedajeEnt> ConsultarHospedaje()
        {
            

            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = conexion.obtenerHospedajesConNombreProvincia().ToList();

                //var datos = (from x in conexion.HOSPEDAJE
                //             select x).ToList();

                List<HospedajeEnt> listaEntidadResultado = new List<HospedajeEnt>();
                foreach (var item in datos)
                {
                    listaEntidadResultado.Add(new HospedajeEnt
                    {
                        Nombre = item.Nombre,
                        NombreProvincia = item.NombreProvincia,
                        Precio = (short)item.Precio,
                        Disponibilidad = item.Disponibilidad

                    });
                }

                return listaEntidadResultado;
            }
        }

        public List<HospedajeEnt> ConsultarMisHospedaje(int q)
        {


            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = conexion.obtenerHospedajesPorUsuario(q).ToList();

                //var datos = (from x in conexion.HOSPEDAJE
                //             select x).ToList();

                List<HospedajeEnt> listaEntidadResultado = new List<HospedajeEnt>();
                foreach (var item in datos)
                {
                    listaEntidadResultado.Add(new HospedajeEnt
                    {
                        FechaRegistro = item.FechaRegistro,
                        Nombre = item.Nombre,
                        NombreProvincia = item.NombreProvincia,
                        Precio = (short)item.Precio,
                        Disponibilidad = item.Disponibilidad,


                    });
                }

                return listaEntidadResultado;
            }
        }

    }
}