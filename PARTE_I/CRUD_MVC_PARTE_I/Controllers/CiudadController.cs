using CRUD_MVC_PARTE_I.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC_PARTE_I.Controllers
{
    public class CiudadController : Controller
    {
        // GET: Ciudad
        public ActionResult Index()
        {
            using(var db = new AlumnosContext())
            {

                return View(db.Ciudad.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Ciudad ci)
        {
            //data annotation son validaciones en el servidor que permiten validar los campos del 
            //modelo. Si edito mi modelo entity framework, se pierden los cambios
            //si el modelo no es el correcto con los datos correctos y adecuados
            //[Required]
            //[Display(Name = "Ingrese nombres")]

            if (!ModelState.IsValid)
            {
                //si se salta la validacion, retorna la misma vista
                return View();
            }
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new AlumnosContext())
                {
                    
                    db.Ciudad.Add(ci);
                    db.SaveChanges();//siempre guardar cambios
                    return RedirectToAction("Index");

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar una CIUDAD - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }


        }

        public ActionResult Edit(int id)
        {
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new AlumnosContext())
                {
                    //First of default si devuelve vacio, no existe, sino toma el primero
                    //Alumno alumno = db.Alumno.Where(objAlumno => objAlumno.Id == id).FirstOrDefault();
                    //Find solo utilizo cuando tenga una sola clave primaria. Si es una clave compuesta no
                    //me sirve. en ese caso utilio where
                    Ciudad ciudad= db.Ciudad.Find(id);
                    return View(ciudad);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar datos de la CIUDAD - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ciudad ci)
        {
            if (!ModelState.IsValid)
            {
                //si se salta la validacion, retorna la misma vista
                return View();
            }
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new AlumnosContext())
                {
                    //primero busco el estudiante
                    Ciudad ciudad = db.Ciudad.Find(ci.Id);
                    //edito los campos 
                    ciudad.Id = ci.Id;
                    
                    //hacer commit
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar la CIUDAD - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new AlumnosContext())
                {

                    Ciudad ciudad = db.Ciudad.Find(id);
                    return View(ciudad);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar datos de la CIUDAD - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new AlumnosContext())
                {
                    Ciudad ciudad = db.Ciudad.Find(id);
                    db.Ciudad.Remove(ciudad);
                    //hago commit
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar la CIUDAD - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }

        }
    }
}