using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModelDB;
using System.Configuration;
using System.Net.Mail;

namespace ProyectoApi_KN.Models
{
    public class LogsModel
    {

        public void RegistrarBitacora(LogsEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                BITACORAS bitacora = new BITACORAS();
                bitacora.FechaHora = entidad.FechaHora;
                bitacora.Origen = entidad.Origen;
                bitacora.DescripcionError = entidad.DescripcionError;

                conexion.BITACORAS.Add(bitacora);
                conexion.SaveChanges();
            }
        }

        public void RegistrarErrores(LogsEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                ERRORES error = new ERRORES();
                error.ConsecutivoUsuario = entidad.ConsecutivoUsuario;
                error.FechaHora = entidad.FechaHora;
                error.Origen = entidad.Origen;
                error.DescripcionError = entidad.DescripcionError;

                conexion.ERRORES.Add(error);
                conexion.SaveChanges();
            }
        }

        public void EnviarCorreo(string destinatario, string asunto, string mensaje)
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

        public void EnviarCorreoContact(CorreoEnt mensaje)
        {

            string usuarioCorreo = ConfigurationManager.AppSettings["usuarioCorreo"].ToString();
            string claveCorreo = ConfigurationManager.AppSettings["claveCorreo"].ToString();
            string destinatario = ConfigurationManager.AppSettings["correoNotificaciones"].ToString();

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(destinatario, "Usuario"));
            msg.From = new MailAddress(usuarioCorreo, "Notificaciones Traveler");
            msg.Subject = mensaje.Asunto;
            msg.Body = "El siguiente correo corresponde al sistema de contacto de Traveler, la consulta la realiza: " + mensaje.Emisor + " ("+ mensaje.CorreoEmisor+")" + "  Consulta: "+ mensaje.CuerpoCorreo;
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

