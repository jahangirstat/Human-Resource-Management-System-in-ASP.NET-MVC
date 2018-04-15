using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCFinalProject.Startup))]
namespace MVCFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
