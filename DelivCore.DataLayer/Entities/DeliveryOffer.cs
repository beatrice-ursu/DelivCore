using System;
using System.ComponentModel.DataAnnotations;
using DelivCore.DataLayer.Entities.Core;

namespace DelivCore.DataLayer.Entities
{
    public class DeliveryOffer : Entity
    {
        public virtual Order Order { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public virtual Person Courier { get; set; }
    }
}