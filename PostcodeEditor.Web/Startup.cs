using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PostcodeEditor.Startup))]
namespace PostcodeEditor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
