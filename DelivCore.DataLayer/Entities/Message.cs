using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.DataLayer.Entities.Core;

namespace DelivCore.DataLayer.Entities
{
    public class Message : Entity
    {
        [Required]
        public string PersonTo { get; set; }
        [Required]
        public string PersonFrom { get; set; }
        [Required]
        public string MessageBody { get; set; }
    }
}
