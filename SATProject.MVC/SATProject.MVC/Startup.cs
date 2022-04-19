using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SATProject.MVC.Startup))]
namespace SATProject.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
