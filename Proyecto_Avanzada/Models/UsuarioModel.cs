using Newtonsoft.Json;
using Proyecto_Avanzada.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Proyecto_Avanzada.Models
{
    public class UsuarioModel
    {
        public UsuarioEnt ValidarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44344/api/ValidarUsuarios";

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<UsuarioEnt>().Result;

                return null;
            }
        }

    }
}