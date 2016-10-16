using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inspecaoViaturasZas.Startup))]
namespace inspecaoViaturasZas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
