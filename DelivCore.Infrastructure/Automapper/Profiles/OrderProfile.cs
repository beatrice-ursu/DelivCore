using AutoMapper;
using DelivCore.DataLayer.Constants;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Orders;
using DelivCore.Models.Persons;
using System;

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

            CreateMap<OrderDto, Order>()
                .ForMember(m => m.Status, a => a.MapFrom(src => StatusConstants.Unprocessed));
            CreateMap<ClientDto, Client>();
            CreateMap<PackageDto, Package>();
        }
    }
}