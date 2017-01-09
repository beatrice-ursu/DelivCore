using System;
using DelivCore.Models.Core;
using DelivCore.Models.Persons;

namespace DelivCore.Models.Orders
{
    public class DeliveryModel: Model
    {
        public DateTime EstimatedDelivery { get; set; }
        public int Order { get; set; }
        public int CourierId { get; set; }

    }
}