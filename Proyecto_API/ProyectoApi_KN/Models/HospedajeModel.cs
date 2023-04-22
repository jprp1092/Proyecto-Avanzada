using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModelDB;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                hospedaje.Disponibilidad = entidad.Disponibilidad;

                conexion.HOSPEDAJE.Add(hospedaje);
                return conexion.SaveChanges();
            }
        }
    }
}