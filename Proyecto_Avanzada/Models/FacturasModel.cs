using Proyecto_Avanzada.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace Proyecto_Avanzada.Models
{
    public class FacturasModel
    {
        public void ConfirmarPago()
        {

            using (var client = new HttpClient())
            {
                FacturasEnt entidad = new FacturasEnt();
                entidad.ConsecutivoUsuario = long.Parse(HttpContext.Current.Session["CodigoUsuario"].ToString());

                JsonContent body = JsonContent.Create(entidad);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                string url = "https://localhost:44398/api/ConfirmarPago";

                client.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }

        public List<FacturasEnt> MostrarFacturas()
        {
            using (var client = new HttpClient())
            {
                long ConsecutivoUsuario = long.Parse(HttpContext.Current.Session["CodigoUsuario"].ToString());
                string url = "https://localhost:44398/api/MostrarFacturas?ConsecutivoUsuario=" + ConsecutivoUsuario;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<List<FacturasEnt>>().Result;

                return new List<FacturasEnt>();
            }
        }
    }
}