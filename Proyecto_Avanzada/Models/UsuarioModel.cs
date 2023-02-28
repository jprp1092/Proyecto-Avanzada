using Newtonsoft.Json;
using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.ModelDB;
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

        public List<UsuarioEnt> ConsultarUsuarios()
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                //var datos = conexion.USUARIOS.ToList().Where(x => x.Estado == true);
                var datos = (from x in conexion.USUARIOS
                             select x).ToList();

                List<UsuarioEnt> listaEntidadResultado = new List<UsuarioEnt>();
                foreach (var item in datos)
                {
                    listaEntidadResultado.Add(new UsuarioEnt
                    {
                        ConsecutivoUsuario = item.ConsecutivoUsuario,
                        CorreoElectronico = item.CorreoElectronico,
                        Estado = item.Estado
                    });
                }

                return listaEntidadResultado;
            }
        }



        public string BuscarCorreo(string correoElectronico)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var resultado = (from x in conexion.USUARIOS
                                 where x.CorreoElectronico == correoElectronico
                                 select x).FirstOrDefault();

                if (resultado == null)
                    return string.Empty;
                else
                {
                    if (resultado.Estado)
                        return "Esta cuenta de correo ya fue registrada anteriormente";
                    else
                        return "Esta cuenta de correo se encuentra inactiva";
                }
            }
        }

        public void RegistrarUsuario(UsuarioEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                USUARIOS usuario = new USUARIOS();
                usuario.CorreoElectronico = entidad.CorreoElectronico;
                usuario.Contrasenna = entidad.Contrasenna;
                usuario.Estado = true;

                conexion.USUARIOS.Add(usuario);
                conexion.SaveChanges();
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