using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace InterviewTestTemplatev2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new UnityContainer();
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterTypes(container);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
