using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HarshTestUserApp.Startup))]
namespace HarshTestUserApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
