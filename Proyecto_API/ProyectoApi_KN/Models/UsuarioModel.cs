using ProyectoApi_KN.App_Start;
using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace ProyectoApi_KN.Models
{
    public class UsuarioModel
    {
        LogsModel model  = new LogsModel();
        TokenGenerator generator = new TokenGenerator();

        public UsuarioEnt ValidarUsuario(UsuarioEnt entidad)
        {
            using (var conexion = new ProyectoWeb_KN_BDEntities())
            {
                //var resultado = conexion.ValidarUsuario(entidad.CorreoElectronico, entidad.Contrasenna).FirstOrDefault();

                var resultado = (from x in conexion.USUARIOS
                                 where x.CorreoElectronico == entidad.CorreoElectronico
                                 && x.Contrasenna == entidad.Contrasenna
                                 && x.Estado == true
                                 select x).FirstOrDefault();

                UsuarioEnt entidadResultado = new UsuarioEnt();
                if (resultado != null)
                {
                    entidadResultado.Token = generator.GenerateTokenJwt(resultado.CorreoElectronico);
                    entidadResultado.ConsecutivoUsuario = resultado.ConsecutivoUsuario;
                    entidadResultado.CorreoElectronico = resultado.CorreoElectronico;
                    return entidadResultado;
                }

                return null;
            }
        }

        public List<UsuarioEnt> ConsultarUsuarios()
        {
            using (var conexion = new ProyectoWeb_KN_BDEntities())
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
            using (var conexion = new ProyectoWeb_KN_BDEntities())
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

        public int RegistrarUsuario(UsuarioEnt entidad)
        {
            using (var conexion = new ProyectoWeb_KN_BDEntities())
            {
                USUARIOS usuario = new USUARIOS();
                usuario.CorreoElectronico = entidad.CorreoElectronico;
                usuario.Contrasenna = entidad.Contrasenna;
                usuario.Estado = true;

                conexion.USUARIOS.Add(usuario);
                return conexion.SaveChanges();
            }
        }

        public void RecuperarContrasenna(UsuarioEnt entidad)
        {

            using (var conexion = new ProyectoWeb_KN_BDEntities())
            {
                var resultado = (from x in conexion.USUARIOS
                                 where x.CorreoElectronico == entidad.CorreoElectronico
                                 select x).FirstOrDefault();

                if (resultado != null)
                {
                    string mensaje = "Su contraseña actual es: " + resultado.Contrasenna;
                    Model.EnviarCorreo(resultado.CorreoElectronico, "Recuperar Contraseña", mensaje);


                }
            }
        }


        
    }
}