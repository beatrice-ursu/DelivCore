using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivCore.DataLayer.Entities
{
    public class OrderOffer
    {

        [Key]
        public int OrderOfferId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string StartAddress { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public int NumberOfPackages { get; set; }
        [Required]
        public int ClientId { get; set; }
        public string Description { get; set; }
    }
}
