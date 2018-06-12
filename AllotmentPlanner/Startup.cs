using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllotmentPlanner.Startup))]
namespace AllotmentPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
