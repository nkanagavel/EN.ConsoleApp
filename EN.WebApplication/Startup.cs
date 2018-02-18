using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EN.WebApplication.Startup))]
namespace EN.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
