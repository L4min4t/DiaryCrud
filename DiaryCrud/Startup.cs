using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiaryCrud.Startup))]
namespace DiaryCrud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
