using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DelivCore.DataLayer.Entities.Core;

namespace DelivCore.DataLayer.Entities
{
    public class Client : Entity
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string InvoiceAddress { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}