using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignatureBusinessSolutionsWebApp.Startup))]
namespace SignatureBusinessSolutionsWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
