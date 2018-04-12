using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(maerskline.Startup))]
namespace maerskline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
