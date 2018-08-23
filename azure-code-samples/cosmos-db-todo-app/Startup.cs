using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cosmos_db_todo_app.Startup))]
namespace cosmos_db_todo_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
