using CRUD_MVC_PARTE_I.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC_PARTE_I.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new AlumnosContext())
                {
                    //List<Alumno> lista = db.Alumno.Where(objAl => objAl.Edad > 18).ToList();
                    // return View(lista);
                    var data = from alumno in db.Alumno
                               join ciudad in db.Ciudad on alumno.CodCiudad equals ciudad.Id
                               select new AlumnoCE()
                               {
                                   Id = alumno.Id,
                                   Nombres = alumno.Nombres,
                                   Apellidos = alumno.Apellidos,
                                   Edad = alumno.Edad,
                                   Sexo = alumno.Sexo,
                                   NombreCiudad = ciudad.Nombre,
                                   FechaRegistro = alumno.FechaRegistro
                               };
                    //return View(db.Alumno.ToList());
                    return View(data.ToList());
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar los ALUMNOS - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Alumno al)
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
                    al.FechaRegistro = DateTime.Now;
                    db.Alumno.Add(al);
                    db.SaveChanges();//siempre guardar cambios
                    return RedirectToAction("Index");

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Error al agregar un alumno - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }
            
            
        }

        public static string NombreCiudad(int CodCiudad)
        {
            using(var db = new AlumnosContext())
            {
                return db.Ciudad.Find(CodCiudad).Nombre;
            }
        }



        public ActionResult AgregarCiudad()
        {
            return View();
        }

        //Se añade el parámetro SelectedCity, que es el id de la ciudad seleccionada
        public ActionResult ListaCiudades(int SelectedCity = 0)
        {
            using(var db = new AlumnosContext())
            {
                //Uso el modelo creado para enviar 2 parametros a la vista,
                //envio la lista de ciudades y el codigo para seleccionar la ciudad
                //del usuario
                var aux = new CityModel
                {
                    ciudades = db.Ciudad.ToList(),
                    CodigoCiudad = SelectedCity
                };
                return PartialView(aux);
            }
        }

        public ActionResult Edit(int Codigo)
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
                    Alumno alumno = db.Alumno.Find(Codigo);
                    return View(alumno);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar datos del ALUMNO - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }
            
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alumno al)
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
                    Alumno alumno = db.Alumno.Find(al.Id);
                    //edito los campos 
                    alumno.Nombres = al.Nombres;
                    alumno.Apellidos = al.Apellidos;
                    alumno.Edad = al.Edad;
                    alumno.Sexo = al.Sexo;
                    //Agregar el codigo de ciudad que se envia
                    alumno.CodCiudad = al.CodCiudad;

                    //hacer commit
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar el ALUMNO - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }
        }

        public ActionResult Details(int Codigo)
        {
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new AlumnosContext())
                {
                    
                    Alumno alumno = db.Alumno.Find(Codigo);
                    return View(alumno);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al listar datos del ALUMNO - " + ex.Message);
                return View();//asi logro mostrar los errores que tengo
            }

        }

        public ActionResult Delete(int Codigo)
        {
            try
            {
                //le decimos que abra la conexion y la cierre
                using (var db = new AlumnosContext())
                {
                    Alumno alumno = db.Alumno.Find(Codigo);
                    db.Alumno.Remove(alumno);
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
    }

}