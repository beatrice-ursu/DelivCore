using System.Collections.Generic;
using DelivCore.Models.Core;
using DelivCore.Models.Persons;

namespace DelivCore.Models.Orders
{
    public class OrderModel : Model
    {
        //Same as Order entity

        public decimal Cost { get; set; }
        public decimal EstimatedDistance { get; set; }
        public string StartAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public bool IsProcessed { get; set; }
        public ClientModel Client { get; set; }
        public IList<PackageModel> Packages { get; set; }

        public string Status { get; set; }
    }
}