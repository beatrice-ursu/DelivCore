using Autofac;
using DelivCore.BusinessLayer.OrderService;
using DelivCore.BusinessLayer.PersonService;
using DelivCore.BusinessLayer.ClientService;
using DelivCore.BusinessLayer.DeliveryOfferService;
using DelivCore.BusinessLayer.DeliveryService;
using DelivCore.BusinessLayer.MessageService;
using DelivCore.BusinessLayer.OrderOfferService;
using DelivCore.DataLayer.Entities;
using DelivCore.BusinessLayer.UserService;

namespace DelivCore.Infrastructure.Autofac
{
    public static partial class AutofacBootstrapper
    {
        private static void RegisterServices(this ContainerBuilder builder)
        {
            //register services
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType<OrderOfferService>().As<IOrderOfferService>();
            builder.RegisterType<DeliveryOfferService>().As<IDeliveryOfferService>();
            builder.RegisterType<DeliveryService>().As<IDeliveryService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MessageService>().As<IMessageService>();

        }
    }
}