using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DelivCore.BusinessLayer.OrderService;
using DelivCore.DataLayer.Constants;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.DeliveryOfferRepository;
using DelivCore.DataLayer.Repositories.DeliveryRepository;
using DelivCore.DataLayer.Repositories.OrderRepository;

namespace DelivCore.BusinessLayer.DeliveryService
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IDeliveryOfferRepository _deliveryOfferRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository, IDeliveryOfferRepository deliveryOfferRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _deliveryOfferRepository = deliveryOfferRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public void AcceptOffer(int id)
        {
            var deliveryOffer = _deliveryOfferRepository.GetById(id);
            var deliveryAccepted = new Delivery
            {
                EstimatedDelivery = deliveryOffer.Time,
                Order = deliveryOffer.Order,
                Courier = deliveryOffer.Courier,
                Active = true,
                CreatedOn = DateTime.Now,
                //todo change this
                CreatedBy = "system"
            };

            _deliveryRepository.Insert(deliveryAccepted);
            //_deliveryRepository.SaveChanges();

            var order = _orderRepository.GetById(deliveryOffer.Order.Id);

            order.Status = StatusConstants.Accepted;
            order.UpdatedBy = "system";
            order.UpdatedOn = DateTime.Now;

            _orderRepository.Update(order);

            _orderRepository.SaveChanges();
        }
    }
}
