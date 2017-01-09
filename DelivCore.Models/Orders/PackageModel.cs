using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Core;

namespace DelivCore.Models.Orders
{
    public class PackageModel : Model
    {
        public decimal Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public OrderModel Order { get; set; }
    }
}
