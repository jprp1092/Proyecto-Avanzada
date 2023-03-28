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
        
        public void ActualizarReserva(ReservasEnt entidad)
        {
           using (var conexion = new ProyectoW_BDEntities())
           {
               var datos = (from x in conexion.RESERVAS
                            where x.ConsecutivoReservas == entidad.ConsecutivoReservas
                            select x).FirstOrDefault();

               datos.FechaReserva = entidad.FechaReserva;
               datos.CodUsuario = entidad.CodUsuario;
               datos.CodDestino = entidad.CodDestino;
               datos.Pago = entidad.Pago;

               conexion.SaveChanges();
           }
        }

        public void CambiarEstado(long q)
        {
           using (var conexion = new ProyectoW_BDEntities())
           {
               var datos = (from x in conexion.RESERVAS
                            where x.ConsecutivoReservas == q
                            select x).FirstOrDefault();

               datos.Estado = (datos.Estado == true ? false : true);
               conexion.SaveChanges();
           }
        }



    }
}
