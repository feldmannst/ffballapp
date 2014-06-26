using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FantasyFootballApp.Startup))]
namespace FantasyFootballApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
