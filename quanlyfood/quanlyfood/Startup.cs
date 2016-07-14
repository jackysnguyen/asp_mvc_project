using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(quanlyfood.Startup))]
namespace quanlyfood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
