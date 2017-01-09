using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Orders;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    public class OrderOfferProfile: Profile
    {
        public OrderOfferProfile()
        {
            CreateMap<OrderOffer, OrderOfferModel>();
            CreateMap<OrderOfferModel, OrderOffer>();
        }
    }
}
