using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tarea_01.Controllers
{
    public class AccessController : Controller
    {
        //// GET: Access
        //public ActionResult Index()
        //{

        //    return View();
        //}

        //private string convertjson(int code, user data)
        //{
        //    string response = "{\"code\":\"" + code + "\",\"username\":\"" + data.email + "\"}";
        //    return response;
        //}

        //public ActionResult Enter(string user, string password)
        //{
        //    try
        //    {
        //        using (cursomvcEntities con = new cursomvcEntities())
        //        {
        //            var row = from data in con.user
        //                      where data.email == user && data.password == password && data.idState == 1
        //                      select data;
        //            if (row.Count() > 0)
        //            {
        //                user obj = row.First();
        //                Session["ListaUser"] = obj;

        //                return Content(this.convertjson(1, obj));
        //            }
        //            else
        //            {
        //                user objerr = new user();
        //                objerr.email = "Usuario invalido :(";
        //                return Content(this.convertjson(-1, objerr));
        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return Content("Ocurrio un error :(" + ex.Message);
        //    }
        //}

        public ActionResult Logoff()
        {
            //cierro sesion con null
            Session["User"] = null;

            //redireccion al login, los parametros son (actionResult,controlador)
            return RedirectToAction("Login", "Account");

        }
    }
}