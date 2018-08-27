using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ws_federation_auth_app.Startup))]
namespace ws_federation_auth_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
