using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityTemplate.Startup))]
namespace IdentityTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
