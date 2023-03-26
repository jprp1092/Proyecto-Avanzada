using Proyecto_Avanzada.Entities;
using System;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;



namespace Proyecto_Avanzada.Models
{ 
 public class LogsModel
{
    public void RegistrarBitacora(ControllerContext origen, string descripcion)
    {
        LogsEnt entidad = new LogsEnt();
        entidad.FechaHora = DateTime.Now;
        entidad.Origen = origen.RouteData.Values["controller"].ToString() + "-" + origen.RouteData.Values["action"].ToString();
        entidad.DescripcionError = descripcion;

        using (var client = new HttpClient())
        {
            JsonContent body = JsonContent.Create(entidad);
            string url = "https://localhost:44398/api/RegistrarBitacora";

            HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();
        }
    }

    public void RegistrarErrores(object usuario, ControllerContext origen, string descripcion)
    {
        LogsEnt entidad = new LogsEnt();
        entidad.ConsecutivoUsuario = long.Parse(usuario.ToString());
        entidad.FechaHora = DateTime.Now;
        entidad.Origen = origen.RouteData.Values["controller"].ToString() + "-" + origen.RouteData.Values["action"].ToString();
        entidad.DescripcionError = descripcion;

        using (var client = new HttpClient())
        {
            JsonContent body = JsonContent.Create(entidad);
            string url = "https://localhost:44398/api/RegistrarErrores";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
            HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();
        }
    }

}
}