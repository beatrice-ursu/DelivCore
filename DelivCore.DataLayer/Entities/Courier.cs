using System.Collections.Generic;

namespace DelivCore.DataLayer.Entities
{
    public class Courier : Person
    {
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}