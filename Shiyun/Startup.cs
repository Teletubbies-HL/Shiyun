using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shiyun.Startup))]
namespace Shiyun
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
