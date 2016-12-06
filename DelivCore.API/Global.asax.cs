using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using DelivCore.Infrastructure.Autofac;

namespace DelivCore.API
{
    public class DelivCoreApi : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var autofacBuidler = AutofacBootstrapper.Configure();
            autofacBuidler.RegisterApiControllers(Assembly.GetExecutingAssembly());
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(autofacBuidler.Build());
        }
    }
}
