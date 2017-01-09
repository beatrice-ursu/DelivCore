using System.ComponentModel.DataAnnotations;
using DelivCore.DataLayer.Entities.Core;

namespace DelivCore.DataLayer.Entities
{
    public class Package : Entity
    {
        public decimal Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        [Required]
        public virtual Order Order { get; set; }
    }
}