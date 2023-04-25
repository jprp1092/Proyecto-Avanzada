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
                             join z in conexion.USUARIOS on x.CodUsuario equals (z.ConsecutivoUsuario)
                             select new
                             {
                                 x.ConsecutivoReservas,x.FechaReserva,x.CodUsuario,z.Nombre,x.CodDestino,x.Pago,x.Estado
                             }).ToList();

                List<ReservasEnt> listaEntidadResultado = new List<ReservasEnt>();
                foreach (var item in datos)
                {
                    listaEntidadResultado.Add(new ReservasEnt
                    {
                        ConsecutivoReservas = item.ConsecutivoReservas,
                        FechaReserva = item.FechaReserva,
                        CodUsuario = item.CodUsuario,
                        NombreUsuario = item.Nombre,
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

        public void AgregarCarrito(HospedajeEnt entidad)
        {

            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = (from x in conexion.CARRITO
                             where x.ConsecutivoUsuario == entidad.ConsecutivoUsuario
                                && x.ConsecutivoHospedaje == entidad.ConsecutivoHospedaje
                             select x).FirstOrDefault();

                if (datos == null)
                {
                    if (entidad.CantidadNoches != 0)
                    {
                        //INSERT
                        CARRITO carrito = new CARRITO();
                        carrito.ConsecutivoHospedaje = Convert.ToInt32(entidad.ConsecutivoHospedaje);
                        carrito.CantNoches = entidad.CantidadNoches;
                        carrito.ConsecutivoUsuario = entidad.ConsecutivoUsuario;
                        carrito.Precio = entidad.Precio;
                        carrito.FechaIngreso = entidad.FechaEntrada;
                        carrito.FechaSalida = entidad.FechaSalida;

                        conexion.CARRITO.Add(carrito);
                        conexion.SaveChanges();
                    }
                }
                else
                {
                    if (entidad.CantidadNoches == 0)
                    {
                        //DELETE
                        conexion.CARRITO.Remove(datos);
                        conexion.SaveChanges();
                    }
                    else
                    {
                        //UPDATE
                        datos.CantNoches = entidad.CantidadNoches;
                        datos.FechaIngreso = entidad.FechaEntrada;
                        datos.FechaSalida = entidad.FechaSalida;

                        conexion.SaveChanges();
                    }
                }

            }
        }

        public CarritoEnt MostrarCarritoTemporal(long ConsecutivoUsuario)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = conexion.MostrarCarritoTemporal(ConsecutivoUsuario).FirstOrDefault();

                CarritoEnt carrito = new CarritoEnt();
                if (datos != null)
                {
                    carrito.CantidadNoches = datos.CantidadNoches;
                    carrito.MontoCarrito = datos.MontoCarrito;
                }

                return carrito;
            }
        }


        public List<CarritoDetalleEnt> MostrarCarritoTotal(long ConsecutivoUsuario)
        {
            using (var conexion = new ProyectoW_BDEntities())
            {
                var datos = conexion.MostrarCarritoTotal(ConsecutivoUsuario).ToList();

                List<CarritoDetalleEnt> carrito = new List<CarritoDetalleEnt>();
                if (datos.Count > 0)
                {
                    foreach (var item in datos)
                    {
                        carrito.Add(new CarritoDetalleEnt
                        {
                            NombreHospedaje = item.NombreHospedaje,
                            CantidadNoches = item.CantidadNoches,
                            Precio = item.Precio,
                            SubTotal = item.SubTotal,
                            Impuesto = item.Impuesto,
                            Total = item.Total
                        });
                    }
                }

                return carrito;
            }
        }
    }
}
