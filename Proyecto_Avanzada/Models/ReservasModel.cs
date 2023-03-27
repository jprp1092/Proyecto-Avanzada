using Proyecto_Avanzada.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;



namespace Proyecto_Avanzada.Models
{ 
 public class ReservasModel
{
        public List<ReservasEnt> ConsultarReservas()
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44398/api/ConsultarReservas";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<List<ReservasEnt>>().Result;

                return new List<ReservasEnt>();
            }
        }

        public ReservasEnt ConsultarReserva(long q)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44398/api/ConsultarUsuario?q=" + q;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<ReservasEnt>().Result;

                return null;
            }
        }
        public int CrearReserva(ReservasEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44398/api/CrearReserva";

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

    }
}