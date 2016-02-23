using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jabber.Startup))]
namespace Jabber
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
