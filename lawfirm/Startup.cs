using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lawfirm.Startup))]
namespace lawfirm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
