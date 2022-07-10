using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_MVC_PARTE_I.Models
{
    public class CityModel
    {
        //Modelo creado para poder ser enviado como retorno de la vista
        public IEnumerable<CRUD_MVC_PARTE_I.Models.Ciudad> ciudades { get; set; }
        public int CodigoCiudad { get; set; }
    }
}