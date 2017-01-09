using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Orders;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    public class DeliveryOfferProfile: Profile
    {
        public DeliveryOfferProfile()
        {
            CreateMap<DeliveryOffer, DeliveryOfferModel>();
            CreateMap<DeliveryOfferModel, DeliveryOffer>();
        }
    }
}