using System.Collections.Generic;
using DelivCore.Models.Core;

namespace DelivCore.Models.Orders
{
    public class OrderOfferModel
    {
        public int OrderId { get; set; }
        public string StartAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public int NumberOfPackages { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
    }
}