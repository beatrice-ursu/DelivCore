using System.Collections.Generic;
using DelivCore.Models.Core;
using DelivCore.Models.Orders;

namespace DelivCore.Models.Persons
{
    public class CourierModel: PersonModel
    {
        public ICollection<DeliveryModel> Deliveries { get; set; }
        public int NoOfOrders { get; set; }
    }
}