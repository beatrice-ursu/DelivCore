using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DelivCore.DataLayer.Entities.Core
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        //Audit
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        [DefaultValue(true)]
        public bool Active { get; set; }
    }
}