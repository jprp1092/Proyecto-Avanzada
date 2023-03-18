using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Proyecto_Avanzada.Controllers
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