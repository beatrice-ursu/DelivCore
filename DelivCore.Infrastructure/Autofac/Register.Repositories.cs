using Autofac;
using DelivCore.DataLayer.Repositories.PersonRepository;

namespace DelivCore.Infrastructure.Autofac
{
    public static partial class AutofacBootstrapper
    {
        private static void RegisterRepositories(this ContainerBuilder builder)
        {
            //register repositories
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
        }
    }
}