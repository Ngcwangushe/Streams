using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Streams.Startup))]
namespace Streams
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
