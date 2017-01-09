
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Orders;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    public class DeliveryProfile: Profile
    {
        public DeliveryProfile()
        {
            CreateMap<Delivery, DeliveryModel>();
            CreateMap<DeliveryModel, Delivery>();
        }
      
    }
}
