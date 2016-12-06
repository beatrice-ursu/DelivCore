using DelivCore.DataLayer.DbContext;
using DelivCore.DataLayer.Entities;

namespace DelivCore.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DelivCore.DataLayer.DbContext.DelivCoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(DelivCoreDbContext context)
        {
            context.Persons.AddOrUpdate(
              p => p.Id,
              new Person { LastName = "Ursu", FirstName = "Robert", Age = 21, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
              new Person { LastName = "Toma", FirstName = "Beatrice", Age = 22, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
              new Person { LastName = "Naidin", FirstName = "Vlad", Age = 23, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now }
            );
        }
    }
}
