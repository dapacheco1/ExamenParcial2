using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Tarea_01.Controllers;
using Tarea_01.Models;

namespace Tarea_01.Filtros
{
    public class Filtro_VERIFICA_SESSION : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var objUser = (ApplicationUser)HttpContext.Current.Session["User"];
            if (objUser == null)
            {
                if (filterContext.Controller is AccountController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Account/Login");
                }
            }
            else
            {
                if (filterContext.Controller is AccountController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}