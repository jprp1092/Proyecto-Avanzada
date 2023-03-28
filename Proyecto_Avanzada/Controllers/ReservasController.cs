﻿using Proyecto_Avanzada.App_Start;
using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Proyecto_Avanzada.Controllers
{
    [SessionFilter]
    public class ReservasController : Controller
    {
        ReservasModel reservasModel = new ReservasModel();
        LogsModel logsModel = new LogsModel();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var resultado = reservasModel.ConsultarReservas();
                return View(resultado);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Home/Index");
            }
        }
        /*
        [HttpGet]
        public ActionResult ActualizarUsuario(long q)
        {
            try
            {
                var resultado = usuariosModel.ConsultarUsuario(q);

                ViewBag.ListaProvincias = provinciasModel.ConsultarProvincias();
                ViewBag.ListaRoles = provinciasModel.ConsultarRoles();

                return View(resultado);
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(UsuarioEnt entidad)
        {
            try
            {
                usuariosModel.ActualizarUsuario(entidad);
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception ex)
            {
                logsModel.RegistrarErrores(Session["CodigoUsuario"], ControllerContext, ex.Message);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult CambiarEstado(long id)
        {
            usuariosModel.CambiarEstado(id);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }*/

    }
}