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
    public class ContactModel
    {
        LogsModel model = new LogsModel();

        public void EnviarCorreoContacto(CorreoEnt mensaje)
        {
            if (mensaje != null)
            {
                model.EnviarCorreoContact(mensaje);
            }

        }

        public int RegistrarCorreoContacto(CorreoEnt mensaje)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                BITACORA_CONTACTO bitacoraC = new BITACORA_CONTACTO();
                bitacoraC.TIPO_MENSAJE = mensaje.Asunto;
                bitacoraC.EMISOR = mensaje.Emisor;
                bitacoraC.CORREO_EMISOR = mensaje.CorreoEmisor;
                bitacoraC.CUERPO_CORREO = mensaje.CuerpoCorreo;
                bitacoraC.FECHA_REGISTRO = mensaje.FechaHora;
                conexion.BITACORA_CONTACTO.Add(bitacoraC);
                return conexion.SaveChanges();
            }
        }
    }
}