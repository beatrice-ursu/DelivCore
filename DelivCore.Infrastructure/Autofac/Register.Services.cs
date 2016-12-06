using Autofac;
using DelivCore.BusinessLayer.PersonService;

namespace DelivCore.Infrastructure.Autofac
{
    public static partial class AutofacBootstrapper
    {
        private static void RegisterServices(this ContainerBuilder builder)
        {
            //register services
            builder.RegisterType<PersonService>().As<IPersonService>();
        }
    }
}