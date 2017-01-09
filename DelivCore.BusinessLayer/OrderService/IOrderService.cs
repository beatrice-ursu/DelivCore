using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Orders;

namespace DelivCore.BusinessLayer.OrderService
{
    public interface IOrderService
    {
        IList<OrderModel> GetAll();
        OrderDetailsModel GetById(int id);
        void UpdateOrderIsProcessed(int id);
        DashboardModel GroupOrders();
    }
}
