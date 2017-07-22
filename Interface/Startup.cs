using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Interface.Startup))]
namespace Interface
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
