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
    }
}