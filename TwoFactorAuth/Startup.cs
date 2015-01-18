using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EBCardsMVC.Startup))]
namespace EBCardsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
