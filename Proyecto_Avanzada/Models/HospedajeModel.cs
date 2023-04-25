using Proyecto_Avanzada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace Proyecto_Avanzada.Models
{
    public class HospedajeModel
    {
        public int RegistrarHospedaje(HospedajeEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44398/api/RegistrarHospedaje";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }


        public List<SelectListItem> ConsultarProvincias()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44398/api/ConsultarProvincias";

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    var listaProvincias = res.Content.ReadFromJsonAsync<List<ProvinciaEnt>>().Result;

                    List<SelectListItem> listaCombo = new List<SelectListItem>();
                    foreach (var item in listaProvincias)
                    {
                        listaCombo.Add(new SelectListItem
                        {
                            Text = item.NombreProvincia,
                            Value = item.CodProvincia.ToString()
                        });
                    }

                    return listaCombo;

                }

                return new List<SelectListItem>();
            }
        }

        public List<HospedajeEnt> ConsultarHospedaje()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44398/api/ConsultarHospedaje";

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<List<HospedajeEnt>>().Result;

                return new List<HospedajeEnt>();
            }
        }
        public List<HospedajeEnt> ConsultarMisHospedaje(int q)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44398/api/ConsultarMisHospedaje?q=" + q;

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<List<HospedajeEnt>>().Result;

                return new List<HospedajeEnt>();
            }
        }

    }
}