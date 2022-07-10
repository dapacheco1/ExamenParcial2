using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tarea_01.Startup))]
namespace Tarea_01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
