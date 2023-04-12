using ProyectoApi_KN.App_Start;
using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModelDB;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoApi_KN.Models
{
    public class UsuarioModel
    {
        LogsModel model  = new LogsModel();
        TokenGenerator generator = new TokenGenerator();

        public UsuarioEnt ValidarUsuario(UsuarioEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
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
                    entidadResultado.Nombre = resultado.Nombre; 
                    entidadResultado.Estado = resultado.Estado;
                    entidadResultado.Rol = resultado.Rol;
                    return entidadResultado;
                }

                return null;
            }
        }

        public List<UsuarioEnt> ConsultarUsuarios()
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = (from x in conexion.USUARIOS
                             select x).ToList();

                List<UsuarioEnt> listaEntidadResultado = new List<UsuarioEnt>();
                foreach (var item in datos)
                {
                    listaEntidadResultado.Add(new UsuarioEnt
                    {
                        ConsecutivoUsuario = item.ConsecutivoUsuario,
                        CorreoElectronico = item.CorreoElectronico,
                        Estado = item.Estado,
                        Nombre = item.Nombre,
                        Telefono = (short)item.Telefono,
                        Identificacion = item.Identificacion

                    });
                }

                return listaEntidadResultado;
            }
        }

        public UsuarioEnt ConsultarUsuario(long q)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = (from x in conexion.USUARIOS
                             where x.ConsecutivoUsuario == q
                             select x).FirstOrDefault();

                UsuarioEnt EntidadResultado = new UsuarioEnt();

                EntidadResultado.ConsecutivoUsuario = datos.ConsecutivoUsuario;
                EntidadResultado.CorreoElectronico = datos.CorreoElectronico;
                EntidadResultado.Estado = datos.Estado;
                EntidadResultado.Nombre = datos.Nombre;
                EntidadResultado.Identificacion = datos.Identificacion;
                EntidadResultado.CodProvincia = datos.CodProvincia.Value;
                EntidadResultado.Rol = datos.Rol;
                EntidadResultado.Telefono = (short)datos.Telefono;
                return EntidadResultado;
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

        public int RegistrarUsuario(UsuarioEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                USUARIOS usuario = new USUARIOS();
                usuario.CorreoElectronico = entidad.CorreoElectronico;
                usuario.Contrasenna = entidad.Contrasenna;
                usuario.Nombre = entidad.Nombre;
                usuario.Estado = true;
                usuario.Identificacion = entidad.Identificacion;
                usuario.Rol = "Usuario";
                usuario.CodProvincia = entidad.CodProvincia;
                usuario.Telefono = entidad.Telefono;
                conexion.USUARIOS.Add(usuario);
                return conexion.SaveChanges();
            }
        }

        public void ActualizarUsuario(UsuarioEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = (from x in conexion.USUARIOS
                             where x.ConsecutivoUsuario == entidad.ConsecutivoUsuario
                             select x).FirstOrDefault();

                datos.Identificacion = entidad.Identificacion;
                datos.Nombre = entidad.Nombre;
                datos.Rol = entidad.Rol;
                datos.CodProvincia = entidad.CodProvincia;

                if (!string.IsNullOrEmpty(entidad.Contrasenna))
                    datos.Contrasenna = entidad.Contrasenna;

                conexion.SaveChanges();
            }
        }

        public void CambiarEstado(long q)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = (from x in conexion.USUARIOS
                             where x.ConsecutivoUsuario == q
                             select x).FirstOrDefault();

                datos.Estado = (datos.Estado == true ? false : true);
                conexion.SaveChanges();
            }
        }

        public void RecuperarContrasenna(UsuarioEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())

            {
                var resultado = (from x in conexion.USUARIOS
                                 where x.CorreoElectronico == entidad.CorreoElectronico
                                 select x).FirstOrDefault();

                if (resultado != null)
                {
                    string mensaje = "Su contraseña actual es: " + resultado.Contrasenna;
                    model.EnviarCorreo(resultado.CorreoElectronico, "Recuperar Contraseña", mensaje);
                }
            }
        }


    }
}
