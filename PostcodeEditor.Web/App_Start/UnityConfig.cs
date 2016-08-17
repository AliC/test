using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PostcodeEditor.Web.Controllers;
using Unity.Mvc5;

namespace PostcodeEditor.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IPostcodeService, PostcodeService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}