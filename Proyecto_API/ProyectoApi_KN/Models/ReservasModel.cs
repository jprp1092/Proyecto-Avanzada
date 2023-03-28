using ProyectoApi_KN.App_Start;
using ProyectoApi_KN.Entities;
using ProyectoApi_KN.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoApi_KN.Models
{
    public class ReservasModel
    {
        LogsModel model  = new LogsModel();

        public int CrearReserva(ReservasEnt entidad)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                ReservasEnt reserva = new ReservasEnt();
                reserva.FechaReserva = entidad.FechaReserva;
                reserva.CodUsuario = entidad.CodUsuario;
                reserva.CodDestino = entidad.CodDestino;
                reserva.Pago = false;
                reserva.Estado = true;
                return conexion.SaveChanges();
            }
        }
        public List<ReservasEnt> ConsultarReservas()
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = (from x in conexion.RESERVAS
                             select x).ToList();

                List<ReservasEnt> listaEntidadResultado = new List<ReservasEnt>();
                foreach (var item in datos)
                {
                    listaEntidadResultado.Add(new ReservasEnt
                    {
                        ConsecutivoReservas = item.ConsecutivoReservas,
                        FechaReserva = item.FechaReserva,
                        CodUsuario = item.CodUsuario,
                        CodDestino = item.CodDestino,
                        Pago = item.Pago,
                        Estado = item.Estado
                    });
                }

                return listaEntidadResultado;
            }
        }
        public ReservasEnt ConsultarReserva(long q)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = (from x in conexion.RESERVAS
                             where x.ConsecutivoReservas == q
                             select x).FirstOrDefault();

                ReservasEnt EntidadResultado = new ReservasEnt();

                EntidadResultado.ConsecutivoReservas = datos.ConsecutivoReservas;
                EntidadResultado.FechaReserva = datos.FechaReserva;
                EntidadResultado.CodUsuario = datos.CodUsuario;
                EntidadResultado.CodDestino = datos.CodDestino;
                EntidadResultado.Pago = datos.Pago;
                EntidadResultado.Estado = datos.Estado;

                return EntidadResultado;
            }
        }
        /*
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
}*/

    }
}
