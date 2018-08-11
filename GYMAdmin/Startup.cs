using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GYMAdmin.Startup))]
namespace GYMAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
