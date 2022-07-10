using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tarea_01.Models
{
    public class PedidosItemsCE
    {
        public int Id { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> PeliculaId { get; set; }
        public Nullable<double> total { get; set; }
        public string Cliente { get; set; }
        public string Pelicula { get; set; }
    }
    [MetadataType(typeof(PedidosItemsCE))]
    public partial class PedidosItems
    {
        public string Cliente { get; set; }
        public string Pelicula { get; set; }

    }
}