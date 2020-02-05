using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopLogin.Startup))]
namespace ShopLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
