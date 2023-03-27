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
    public class ProvinciaModel
{

    public List<SelectListItem> ConsultarProvincias()
    {
        using (var client = new HttpClient())
        {
            string url = "https://localhost:44398/api/ConsultarProvincias";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
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

    public List<SelectListItem> ConsultarRoles()
    {
        List<SelectListItem> listaCombo = new List<SelectListItem>();

        listaCombo.Add(new SelectListItem { Text = "Administrador", Value = "Admin" });
        listaCombo.Add(new SelectListItem { Text = "Usuario", Value = "User" });

        return listaCombo;
    }

}
}