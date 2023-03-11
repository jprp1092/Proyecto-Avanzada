using Newtonsoft.Json;
using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.ModelDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Avanzada.Models
{
    public class UsuarioModel
    {
        public UsuarioEnt ValidarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44398/api/ValidarUsuarios";

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


            public string BuscarCorreo(string correoElectronico)
        {
            using (var client = new HttpClient())
            {

                string url = "https://localhost:44398/api/BuscarCorreo?correoElectronico=" + correoElectronico;

                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<string>().Result;

                return  "ERROR";
            }

        }

        public int RegistrarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44398/api/RegistrarUsuarios";

                HttpResponseMessage res = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<int>().Result;

                return 0;
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

        public void RegistrarBitacora(string origen, string descripcion)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                //conexion.RegistrarBitacora(origen, descripcion);

                BITACORA bitacora = new BITACORA();
                bitacora.FechaHora = DateTime.Now;
                bitacora.Origen = origen;
                bitacora.DescripcionError = descripcion;

                conexion.BITACORA.Add(bitacora);
                conexion.SaveChanges();
            }
        }

        public void RegistrarErrores(object usuario, string origen, string descripcion)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                ERRORES error = new ERRORES();
                error.ConsecutivoUsuario = long.Parse(usuario.ToString());
                error.FechaHora = DateTime.Now;
                error.Origen = origen;
                error.DescripcionError = descripcion;

                conexion.ERRORES.Add(error);
                conexion.SaveChanges();
            }
        }




    }
    }