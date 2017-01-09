using System;
using System.ComponentModel.DataAnnotations;
using DelivCore.DataLayer.Entities.Core;

namespace DelivCore.DataLayer.Entities
{
    public class Delivery : Entity
    {
        public TimeSpan EstimatedDelivery { get; set; }
        [Required]
        public virtual Order Order { get; set; }
        [Required]
        public virtual Person Courier { get; set; }
    }
}