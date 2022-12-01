using MVC_AppFrwk.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MVC_AppFrwk
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // Register the Dependency
            container.RegisterType<IServ, EmployeeService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}