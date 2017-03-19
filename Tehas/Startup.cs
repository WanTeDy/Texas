using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tehas.Frontend.Startup))]
namespace Tehas.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
