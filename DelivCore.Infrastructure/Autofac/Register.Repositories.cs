using Autofac;
using DelivCore.DataLayer.Repositories.ClientRepository;
using DelivCore.DataLayer.Repositories.DeliveryOfferRepository;
using DelivCore.DataLayer.Repositories.DeliveryRepository;
using DelivCore.DataLayer.Repositories.MessageRepository;
using DelivCore.DataLayer.Repositories.OrderOfferRepository;
using DelivCore.DataLayer.Repositories.OrderRepository;
using DelivCore.DataLayer.Repositories.PersonRepository;

namespace DelivCore.Infrastructure.Autofac
{
    public static partial class AutofacBootstrapper
    {
        private static void RegisterRepositories(this ContainerBuilder builder)
        {
            //register repositories
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<ClientRepository>().As<IClientRepository>();
            builder.RegisterType<OrderOfferRepository>().As<IOrderOfferRepository>();
            builder.RegisterType<DeliveryOfferRepository>().As<IDeliveryOfferRepository>();
            builder.RegisterType<DeliveryRepository>().As<IDeliveryRepository>();
            builder.RegisterType<MessageRepository>().As<IMessageRepository>();

        }
    }
}