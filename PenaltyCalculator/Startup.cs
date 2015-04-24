using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PenaltyCalculator.Startup))]
namespace PenaltyCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
