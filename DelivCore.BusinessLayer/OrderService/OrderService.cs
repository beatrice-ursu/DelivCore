using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DelivCore.DataLayer.Constants;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.DeliveryRepository;
using DelivCore.DataLayer.Repositories.OrderRepository;
using DelivCore.Models.Orders;
using DelivCore.Models.Layout;

namespace DelivCore.BusinessLayer.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryRepository _deliveryRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, IDeliveryRepository deliveryRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _deliveryRepository = deliveryRepository;
        }

        public IList<OrderModel> GetAll()
        {
            var ordersEntities = _orderRepository.GetAll();
            var orders = ordersEntities.Select(x => _mapper.Map<OrderModel>(x)).ToList();
            return orders;
        }

        public OrderDetailsModel GetById(int id)
        {
            var orderEntity = _orderRepository.GetById(id);
            var order = _mapper.Map<OrderDetailsModel>(orderEntity);

            if (order.Status == StatusConstants.Accepted)
            {
                var deliveryEntity = _deliveryRepository.GetAll().FirstOrDefault(x => x.Order.Id == id);
                order.DeliveryDetails = _mapper.Map<DeliveryModel>(deliveryEntity);
            }

            return order;
        }

        public void UpdateOrderIsProcessed(int id)
        {
            var order = _orderRepository.GetById(id);
            order.Status = StatusConstants.Processed;
            _orderRepository.Update(order);
            _orderRepository.SaveChanges();
        }

        public DashboardModel GroupOrders()
        {
            var allOrders = _orderRepository.GetAll().ToList();
            var dashboardModel = new DashboardModel();
            foreach (var item in allOrders)
            {
                switch (item.Status)
                {
                    case StatusConstants.Processed:
                        dashboardModel.ProcessedOrders++;
                        break;
                    case StatusConstants.Accepted:
                        dashboardModel.AcceptedOrders++;
                        break;
                    default:
                        dashboardModel.UnprocessedOrders++;
                        break;
                }
            }
            dashboardModel.AllOrders = allOrders.Count();
            return dashboardModel;
        }

        public List<OrderModel> GroupOrdersByUser(string user)
        {
            var allOrdersEntities = _orderRepository.GetAll().Where(x => x.CreatedBy == user).ToList();
            var allOrder = allOrdersEntities.Select(x => _mapper.Map<OrderModel>(x)).ToList();

            return allOrder;
        }
    }
}
