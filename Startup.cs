using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShapeDrawer.Startup))]
namespace ShapeDrawer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
