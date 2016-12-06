using System;
using System.ComponentModel.DataAnnotations;

namespace DelivCore.DataLayer.Entities.Core
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        //Audit
        public DateTime CreatedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual string UpdatedBy { get; set; }
    }
}