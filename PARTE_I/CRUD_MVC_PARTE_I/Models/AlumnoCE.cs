using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//ESTA ES MI CLASE PARCIAL
namespace CRUD_MVC_PARTE_I.Models
{
    public class AlumnoCE
    {
        //asi validamos los campos del modelo generado por entity framework
        //el nombre de propiedades son las mismas que entoty framework, tomar en cuenta los cambios
        //generados.
        [Required]
        [Display(Name = "Ingrese los nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Ingrese los apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Ingrese la edad del alumno")]
        public Nullable<int> Edad { get; set; }

        [Required]
        [Display(Name = "Ingrese el genero del alumno")]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Seleccione la ciudad")]
        public int CodCiudad { get; set; }

        
        public string NombreCiudad { get; set; }
        public int Id { get; set; }
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }

        public System.DateTime FechaRegistro { get; set; }
        ////puedo agregar mas cosas o campos de otras tablas
        //public int Estado { get;set; }
    }

    [MetadataType(typeof(AlumnoCE))]
    public partial class Alumno
    {
        //AQUI PONER PROPIEDADES QUE NO TENGA EN MI MODELO DE LA BD, SE HACE UNA DOBLE DEFINICION
        //es una propiedad de lectura
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
        public string NombreCiudad { get; set; }
 
    }
}