using Autofac;
using AutoMapper;
using DelivCore.Infrastructure.Automapper;

namespace DelivCore.Infrastructure.Autofac
{
    public static partial class AutofacBootstrapper
    {
        public static ContainerBuilder Configure()
        {
            var builder = new ContainerBuilder();

            //Core
            builder.Register(x => AutomapperBootstrapper.GetConfiguration()).SingleInstance().AutoActivate().AsSelf();
            builder.Register(x => x.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();

            //Repositories
            builder.RegisterRepositories();

            //Services
            builder.RegisterServices();

            return builder;
        }
    }
}