using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ooad2020E_schedule.Startup))]
namespace ooad2020E_schedule
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
