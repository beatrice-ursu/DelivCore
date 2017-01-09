using System;
using DelivCore.Models.Core;
using DelivCore.Models.Persons;

namespace DelivCore.Models.Orders
{
    public class DeliveryOfferModel : Model
    {
        public int OrderId { get; set; }
        public TimeSpan Time { get; set; }
        public CourierModel Courier { get; set; }
    }
}