using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Core;
using DelivCore.Models.Orders;

namespace DelivCore.Models.Persons
{
    public class ClientModel : Model
    {
        public string LastName { get; set; }
        public string Address { get; set; }
        public string InvoiceAddress { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}
