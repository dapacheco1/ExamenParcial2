using System.Web;
using System.Web.Mvc;

namespace Tarea_01
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filtros.Filtro_VERIFICA_SESSION());
        }
    }
}
