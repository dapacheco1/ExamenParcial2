using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea_01.Models;

namespace Tarea_01.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (PELICULAS_DBEntities db = new PELICULAS_DBEntities())
            {
                return View(db.clientes.ToList());
            }
                
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new PELICULAS_DBEntities())
                {
                    clientes cliente = db.clientes.Find(id);
                    return View(cliente);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar datos de la CLIENTE - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(clientes cli)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new PELICULAS_DBEntities())
                {
                    db.clientes.Add(cli);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear CLIENTE -" + ex.Message);
                return View();

            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(clientes cli)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new PELICULAS_DBEntities())
                {
                    

                    clientes cliente = db.clientes.Find(cli.Id);
                    cliente.Nombres = cli.Nombres;
                    cliente.Apellidos = cli.Apellidos;
                    cliente.telefono = cli.telefono;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear CLIENTE -" + ex.Message);
                return View();

            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new PELICULAS_DBEntities())
                {

                    clientes cliente = db.clientes.Find(id);
                    return View(cliente);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar datos del CLIENTE - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }

        }

        public ActionResult Delete(int id)
        {

            if (User.IsInRole("Administrador") || User.IsInRole("Cliente"))
            {

                try
                {
                    //le decimos que abra la conexion y la cierre
                    using (var db = new PELICULAS_DBEntities())
                    {
                        clientes cliente = db.clientes.Find(id);
                        db.clientes.Remove(cliente);
                        //hago commit
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al eliminar el CLIENTE - " + ex.Message);
                    return View();//asi logro mostrar los errores que tengo
                }
            }
            else
            {
                return View();
            }
           

        }

        public ActionResult Compras(string userId)
        //public ActionResult Compras(int id)
        {
            using (var db = new PELICULAS_DBEntities())
            {
                var aux = db.clientes.First(item => item.userId == userId);
                int id = aux.Id;
                var data = from PedidosItems in db.PedidosItems
                           join clientes in db.clientes on PedidosItems.ClienteId equals clientes.Id
                           join peliculas in db.peliculas on PedidosItems.PeliculaId equals peliculas.id
                           where clientes.Id == id
                           select new PedidosItemsCE()
                           {
                               Id = PedidosItems.Id,
                               Cliente = clientes.Nombres,
                               Pelicula = peliculas.titulo,
                               total = PedidosItems.total
                           };
                return View(data.ToList());
            }
        }
    }
}