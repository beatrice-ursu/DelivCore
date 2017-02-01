using DelivCore.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivCore.Models.Orders
{
    public class OrderDto
    {
        public decimal Cost { get; set; }
        public decimal EstimatedDistance { get; set; }
        public string StartAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public ClientDto Client { get; set; }
        public IList<PackageDto> Packages { get; set; }
    }
}
