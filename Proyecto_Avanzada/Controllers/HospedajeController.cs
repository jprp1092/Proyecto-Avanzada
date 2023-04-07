using Proyecto_Avanzada.App_Start;
using Proyecto_Avanzada.Entities;
using Proyecto_Avanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Avanzada.Controllers
{
    [AfliliadoFilter]
    public class HospedajeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}