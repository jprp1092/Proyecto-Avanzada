using Newtonsoft.Json;
using Proyecto_Avanzada.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Xml;


namespace Proyecto_Avanzada.Models
{
    //Todas las funciones
    public class UsuarioModel
    {
        /*
           1. Nivel de acceso: Public Private
           2. Retorno del mÃ©todo int, decimal, string, datetime, boolean, Objeto, List<Objeto>
           3. ParÃ¡metros de entrada int, decimal, string, datetime, boolean, Objeto, List<Objeto>
        */
        public UsuarioEnt ValidarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44398/api/ValidarUsuario";

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<UsuarioEnt>().Result;

                return null;
            }
        }

        public List<UsuarioEnt> ConsultarUsuarios()
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44398/api/ConsultarUsuarios";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;

                return new List<UsuarioEnt>();
            }
        }

        public UsuarioEnt ConsultarUsuario(long q)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44398/api/ConsultarUsuario?q=" + q;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<UsuarioEnt>().Result;

                return null;
            }
        }

        public string BuscarCorreo(string correoElectronico)
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44398/api/BuscarCorreo?correoElectronico=" + correoElectronico;

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<string>().Result;

                return "ERROR";
            }

        }

        public int RegistrarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44398/api/RegistrarUsuario";

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public void ActualizarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                string url = "https://localhost:44398/api/ActualizarUsuario";

                client.PutAsync(url, body).GetAwaiter().GetResult();
            }
        }

        public void CambiarEstado(long q)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                string url = "https://localhost:44398/api/CambiarEstado?q=" + q;

                client.DeleteAsync(url).GetAwaiter().GetResult();
            }
        }

        public void RecuperarContrasenna(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44398/api/RecuperarContrasenna";

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }

    }
}
