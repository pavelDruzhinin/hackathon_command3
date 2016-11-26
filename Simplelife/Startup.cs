using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simplelife.Startup))]
namespace Simplelife
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
