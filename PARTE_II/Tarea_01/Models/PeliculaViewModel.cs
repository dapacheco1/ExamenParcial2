using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarea_01.Models
{

    public class PeliculaViewModel
    {

        public int id { get; set; }
        public string titulo { get; set; }
        public int duracion { get; set; }
        public DateTime publicacion { get; set; }
        public string pais { get; set; }
        public byte[] imagen { get; set; }
    }
}