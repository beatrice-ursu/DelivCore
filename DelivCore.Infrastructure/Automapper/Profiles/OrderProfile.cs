using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Orders;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderModel>();
            CreateMap<OrderModel, Order>();
            CreateMap<Order, OrderDetailsModel>();
            CreateMap<OrderDetailsModel, Order>();
        }
    }
}