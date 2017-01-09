using System;

namespace DelivCore.Models.Core
{
    public class Model
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual string UpdatedBy { get; set; }
        public bool Active { get; set; }
    }
}