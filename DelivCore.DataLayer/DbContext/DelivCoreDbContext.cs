using System.Data.Entity;
using DelivCore.DataLayer.Entities;

namespace DelivCore.DataLayer.DbContext
{
    public class DelivCoreDbContext : System.Data.Entity.DbContext
    {
        public DelivCoreDbContext() : base("DelivCoreConnectionString") { }
        public DbSet<Person> People { get; set; }
        public DbSet<Client> Clients { get; set; }
        //public DbSet<Courier> Couriers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryOffer> DeliveryOffers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderOffer> OrderOffers { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}