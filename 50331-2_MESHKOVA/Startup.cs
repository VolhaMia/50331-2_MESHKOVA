using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_50331_2_MESHKOVA.Startup))]
namespace _50331_2_MESHKOVA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
