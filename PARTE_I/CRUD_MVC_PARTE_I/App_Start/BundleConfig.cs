using System.Web;
using System.Web.Optimization;

namespace CRUD_MVC_PARTE_I
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            // "~/Scripts/bootstrap.js",
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Content/js/scripts.js"));
            //"~/Content/bootstrap.css"
            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/css/styles.css"));

            bundles.Add(new ScriptBundle("~/bundlesbs3/bootstrap").Include(
                     "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Contentbs3/css").Include(
                      "~/Content/bs3/bootstrap.css",
                      "~/Content/bs3/site.css"));
        }
    }
}
