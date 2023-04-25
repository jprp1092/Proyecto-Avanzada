using Proyecto_Avanzada.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Globalization;



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
        public void ActualizarReserva(ReservasEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                string url = "https://localhost:44398/api/ActualizarUsuario";

                client.PutAsync(url, body).GetAwaiter().GetResult();
            }
        }
        public void CambiarEstado(long id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                string url = "https://localhost:44398/api/CambiarEstado?q=" + id;

                client.DeleteAsync(url).GetAwaiter().GetResult();
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

        public void AgregarCarrito(long ConsecutivoHospedaje, int CantidadNoches, float precio, string FechaEntrada, string FechaSalida)
        {
            DateTime fechaIngreso = DateTime.ParseExact(FechaEntrada, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime fechaSalida = DateTime.ParseExact(FechaSalida, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            using (var client = new HttpClient())
            {

                HospedajeEnt reserva = new HospedajeEnt();
                reserva.ConsecutivoHospedaje = ConsecutivoHospedaje;
                reserva.CantidadNoches = CantidadNoches;
                reserva.Precio = precio;
                reserva.FechaEntrada = fechaIngreso;
                reserva.FechaSalida = fechaSalida;
                reserva.ConsecutivoUsuario = int.Parse(HttpContext.Current.Session["CodigoUsuario"].ToString());

                JsonContent body = JsonContent.Create(reserva);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                string url = "https://localhost:44398/api/AgregarCarrito";

                client.PutAsync(url, body).GetAwaiter().GetResult();
            }
        }

        public CarritoEnt MostrarCarritoTemporal()
        {
            using (var client = new HttpClient())
            {
                long ConsecutivoUsuario = long.Parse(HttpContext.Current.Session["CodigoUsuario"].ToString());
                string url = "https://localhost:44398/api/MostrarCarritoTemporal?IdUsuario=" + ConsecutivoUsuario;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<CarritoEnt>().Result;

                return new CarritoEnt();
            }
        }

        public List<CarritoDetalleEnt> MostrarCarritoTotal()
        {
            using (var client = new HttpClient())
            {
                long ConsecutivoUsuario = long.Parse(HttpContext.Current.Session["CodigoUsuario"].ToString());
                string url = "https://localhost:44398/api/MostrarCarritoTotal?ConsecutivoUsuario=" + ConsecutivoUsuario;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["TokenUsuario"].ToString());
                HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                    return res.Content.ReadFromJsonAsync<List<CarritoDetalleEnt>>().Result;

                return new List<CarritoDetalleEnt>();
            }
        }

    }
}