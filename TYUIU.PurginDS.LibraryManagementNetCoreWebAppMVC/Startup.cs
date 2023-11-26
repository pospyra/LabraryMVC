using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC.Startup))]
namespace TYUIU.PurginDS.LibraryManagementNetCoreWebAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
