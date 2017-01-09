using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivCore.Models.Orders
{
    public class DashboardModel
    {
        public int AllOrders { get; set; }
        public int UnprocessedOrders { get; set; }
        public int ProcessedOrders { get; set; }
        public int AcceptedOrders { get; set; }
    }
}
