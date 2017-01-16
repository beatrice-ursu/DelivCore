using System.Collections.Generic;
using DelivCore.Models.Core;
using DelivCore.Models.Persons;

namespace DelivCore.Models.Orders
{
    public class OrderDetailsModel: Model
    {
        public decimal Cost { get; set; }
        public decimal EstimatedDistance { get; set; }
        public string StartAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public ClientModel Client { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DeliveryModel DeliveryDetails { get; set; }
    }
}