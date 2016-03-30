using Microsoft.Practices.Unity;
using System.Web.Http;
using Group04_CMS.Services;
using Unity.WebApi;
using System.Web.Mvc;

namespace Group04_CMS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container
                .RegisterType<IAccountService, AccountService>()
                .RegisterType<IFacultyService,FacultyService>();
            
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}