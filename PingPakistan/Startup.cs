using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PingPakistan.Startup))]
namespace PingPakistan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
