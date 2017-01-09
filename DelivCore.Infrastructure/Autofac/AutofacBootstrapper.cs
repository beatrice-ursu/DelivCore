using Autofac;
using AutoMapper;
using DelivCore.DataLayer.DbContext;
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
            builder.RegisterType<DelivCoreDbContext>().AsSelf().InstancePerRequest();

            //Repositories
            builder.RegisterRepositories();

            //Services
            builder.RegisterServices();

            return builder;
        }
    }
}