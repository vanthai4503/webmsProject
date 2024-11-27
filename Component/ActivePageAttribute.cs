using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web_music.Component
{
    // thêm active 
    public class ActivePageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            filterContext.Controller.ViewBag.ControllerName = controllerName;
            base.OnActionExecuting(filterContext);
        }
    }
}