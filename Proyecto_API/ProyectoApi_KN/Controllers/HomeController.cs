﻿using ProyectoApi_KN.ModelDB;
using ProyectoApi_KN.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoApi_KN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            return View();
        }
    }
}
