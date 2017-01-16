using System;
using DelivCore.Models.Core;
using DelivCore.Models.Persons;

namespace DelivCore.Models.Orders
{
    public class DeliveryModel: Model
    {
        public TimeSpan EstimatedDelivery { get; set; }
        public int OrderId { get; set; }
        public string CourierName { get; set; }

    }
}