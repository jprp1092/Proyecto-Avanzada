using System;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Proyecto_Avanzada.App_Start
{
    public class SessionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (filterContext.HttpContext.Session.Count == 0)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Index" }
                });
        }

        base.OnActionExecuting(filterContext);
    }
}
}