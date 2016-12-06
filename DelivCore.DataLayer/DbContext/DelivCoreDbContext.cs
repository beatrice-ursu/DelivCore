using System.Data.Entity;
using DelivCore.DataLayer.Entities;

namespace DelivCore.DataLayer.DbContext
{
    public class DelivCoreDbContext : System.Data.Entity.DbContext
    {
        public DelivCoreDbContext() : base("DelivCoreConnectionString") { }
        public DbSet<Person> Persons { get; set; }
    }
}