using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tarea_01.Models
{
    public class PedidosItemsController : Controller
    {
        // GET: PedidosItems
        public ActionResult Index(int ids)
        {
            using(var db = new PELICULAS_DBEntities())
            {
                var list = db.PedidosItems.Where(item => item.ClienteId == ids);
                return View(list);
            }
            
        }
    }
}