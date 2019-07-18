using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Layered.AspnetWebApi.Startup))]

namespace Layered.AspnetWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
