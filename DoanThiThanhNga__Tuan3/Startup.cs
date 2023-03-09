using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoanThiThanhNga__Tuan3.Startup))]
namespace DoanThiThanhNga__Tuan3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
