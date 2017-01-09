using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DelivCore.DataLayer.Entities.Core;

namespace DelivCore.DataLayer.Entities
{
    public class Order : Entity
    {
        public decimal Cost { get; set; }
        public decimal EstimatedDistance { get; set; }
        [Required]
        public string StartAddress { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        public virtual ICollection<Package> Packages { get; set; }

        public string Status { get; set; }
    }
    
}