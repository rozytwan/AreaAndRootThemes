using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DenimSACCOS.Startup))]
namespace DenimSACCOS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
