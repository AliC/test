using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PostcodeEditor.SeparatedInterfaces;
using Unity.Mvc5;

namespace PostcodeEditor.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            UnityContainer container = new UnityContainer();
            
            container.RegisterType<IPostcodeService, Core.PostcodeService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}