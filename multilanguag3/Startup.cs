using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(multilanguag3.Startup))]
namespace multilanguag3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
