using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.DeliveryOfferRepository;
using DelivCore.Models.Orders;

namespace DelivCore.BusinessLayer.DeliveryOfferService
{
    public class DeliveryOfferService : IDeliveryOfferService
    {
        private readonly IDeliveryOfferRepository _deliveryOfferRepository;
        private readonly IMapper _mapper;

        public DeliveryOfferService(IDeliveryOfferRepository deliveryOfferRepository, IMapper mapper)
        {
            _deliveryOfferRepository = deliveryOfferRepository;
            _mapper = mapper;
        }

        public IList<DeliveryOfferModel> GetAllById(int id)
        {
            var deliveryOfferEntities = _deliveryOfferRepository.GetAll();
            deliveryOfferEntities = deliveryOfferEntities.Where(x => x.Order.Id == id);
            var deliveryOffer = deliveryOfferEntities.Select(x => _mapper.Map<DeliveryOfferModel>(x)).ToList();
            return deliveryOffer;
        }
    }
}