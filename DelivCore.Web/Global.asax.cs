using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using DelivCore.Infrastructure.Autofac;

namespace DelivCore.Web
{
    public class DelivCore : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var autofacBuidler = AutofacBootstrapper.Configure();
            autofacBuidler.RegisterControllers(typeof(DelivCore).Assembly);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(autofacBuidler.Build()));
        }
    }
}
