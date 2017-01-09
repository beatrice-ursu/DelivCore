using System;
using AutoMapper;
using DelivCore.BusinessLayer.OrderService;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.OrderOfferRepository;
using DelivCore.Models.Orders;

namespace DelivCore.BusinessLayer.OrderOfferService
{
    public class OrderOfferService : IOrderOfferService
    {
        private readonly IOrderService _orderService;
        private readonly IOrderOfferRepository _orderOfferRepository;
        private readonly IMapper _mapper;

        public OrderOfferService(IOrderService orderService, IOrderOfferRepository orderOfferRepository, IMapper mapper)
        {
            _orderService = orderService;
            _orderOfferRepository = orderOfferRepository;
            _mapper = mapper;
        }
        public void CreateOrderOffer(int OrderId, string OrderDescription)
        {
            var order = _orderService.GetById(OrderId);
            var orderOffer = new OrderOffer
            {
                OrderId = OrderId,
                ClientId = order.Client.Id,
                DeliveryAddress = order.DeliveryAddress,
                StartAddress = order.StartAddress,
                Description = OrderDescription
            };
            _orderOfferRepository.Insert(orderOffer);
            _orderOfferRepository.SaveChanges();
            _orderService.UpdateOrderIsProcessed(OrderId);
        }
    }
}