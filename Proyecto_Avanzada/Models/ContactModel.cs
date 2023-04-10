using Proyecto_Avanzada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace Proyecto_Avanzada.Models
{
    public class ContactModel
    {

        public void EnvioCorreoContacto(CorreoEnt mensaje)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(mensaje);
                string url = "https://localhost:44398/api/EnvioCorreoContacto";

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }

    }
}