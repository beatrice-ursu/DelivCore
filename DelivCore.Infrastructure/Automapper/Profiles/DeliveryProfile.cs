
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Orders;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    public class DeliveryProfile: Profile
    {
        public DeliveryProfile()
        {
            CreateMap<Delivery, DeliveryModel>().ForMember(x => x.CourierName, a => a.MapFrom(x => x.Courier.FirstName + " " + x.Courier.LastName));
            CreateMap<DeliveryModel, Delivery>();
        }
      
    }
}
