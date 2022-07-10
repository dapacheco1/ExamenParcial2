using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Tarea_01.Models;

namespace Tarea_01.Controllers
{
    public class PeliculaController : Controller
    {
        public ActionResult getImage(int id)
        {
            using(var db = new PELICULAS_DBEntities())
            {
                peliculas pelicula = db.peliculas.Find(id);
                byte[] byteImg = pelicula.imagen;

                MemoryStream ms = new MemoryStream(byteImg);
                Image img = Image.FromStream(ms);

                ms = new MemoryStream();
                img.Save(ms, ImageFormat.Jpeg);
                ms.Position = 0;

                return File(ms, "image/jpg");

            }
        }
        // GET: Pelicula
        public ActionResult Index()
        {
            List<PeliculaViewModel> list = null;
            using (PELICULAS_DBEntities db = new PELICULAS_DBEntities())
            {

                //LINQ
                list = (from data in db.peliculas
                        orderby data.publicacion
                        select new PeliculaViewModel
                        {
                            id = data.id,
                            titulo = data.titulo,
                            duracion = (int)data.duracion,
                            publicacion = (DateTime)data.publicacion,
                            pais = data.pais,
                            imagen = data.imagen
                        }).ToList();
            }
                return View(list);
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
                using(var db  = new PELICULAS_DBEntities())
                {
                    peliculas pelicula = db.peliculas.Find(id);
                    return View(pelicula);
                }

            }catch(Exception ex)
            {
                ModelState.AddModelError("", "Error al listar datos de la PELICULA - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }
            
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(peliculas peli)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            WebImage image = new WebImage(FileBase.InputStream);
            peli.imagen = image.GetBytes();
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using(var db = new PELICULAS_DBEntities())
                {
                    db.peliculas.Add(peli);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("","Error al crear PELICULA -"+ex.Message);
                return View();

            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(peliculas peli)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var db = new PELICULAS_DBEntities())
                {
                    HttpPostedFileBase FileBase = Request.Files[0];
                    WebImage image = new WebImage(FileBase.InputStream);
                    peli.imagen = image.GetBytes();

                    peliculas pelicula = db.peliculas.Find(peli.id);
                    pelicula.titulo = peli.titulo;
                    pelicula.duracion = peli.duracion;
                    pelicula.pais = peli.pais;
                    pelicula.imagen = peli.imagen;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear PELICULA -" + ex.Message);
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

                    peliculas pelicula = db.peliculas.Find(id);
                    return View(pelicula);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar datos del ALUMNO - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }

        }

        public ActionResult Delete(int id)
        {
            if (User.IsInRole("Administrador"))
            {

                try
                {
                    //le decimos que abra la conexion y la cierre
                    using (var db = new PELICULAS_DBEntities())
                    {
                        peliculas pelicula = db.peliculas.Find(id);
                        db.peliculas.Remove(pelicula);
                        //hago commit
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al eliminar el ALUMNO - " + ex.Message);
                    return View();//asi logro mostrar los errores que tengo
                }
            }
            else
            {
                return View();
            }

        }
    }
}