using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProyectoApi_KN.Models
{
    public class LogsModel
    {


        private void EnviarCorreo(string destinatario, string asunto, string mensaje)
        {

            string usuarioCorreo = ConfigurationManager.AppSettings["usuarioCorreo"].ToString();
            string claveCorreo = ConfigurationManager.AppSettings["claveCorreo"].ToString();

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(destinatario, "Usuario"));
            msg.From = new MailAddress(usuarioCorreo, "Admin");
            msg.Subject = asunto;
            msg.Body = mensaje;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(usuarioCorreo, claveCorreo);
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Send(msg);
        }



    }
}