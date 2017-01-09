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
        NavbarModel GroupOrdersByUser(string user);
    }
}
