using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalonHappiness.Startup))]
namespace SalonHappiness
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
