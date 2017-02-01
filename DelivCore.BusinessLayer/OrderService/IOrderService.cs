using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Orders;
using DelivCore.Models.Layout;

namespace DelivCore.BusinessLayer.OrderService
{
    public interface IOrderService
    {
        IList<OrderModel> GetAll();
        OrderDetailsModel GetById(int id);
        void UpdateOrderIsProcessed(int id);
        DashboardModel GroupOrders();
        List<OrderModel> GroupOrdersByUser(string user);
        bool SaveOrders(IEnumerable<OrderDto> orders);
    }
}
