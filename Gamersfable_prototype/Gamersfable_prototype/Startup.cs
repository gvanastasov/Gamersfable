using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gamersfable_prototype.Startup))]
namespace Gamersfable_prototype
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
