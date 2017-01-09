using System.Data.Entity.Validation;
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
            try
            {
                context.Clients.AddOrUpdate(
                    c => c.Id,
                    new Client
                    {
                        LastName = "Beatrice",
                        Address = "My Address",
                        InvoiceAddress = "For Delivery Address",
                        CreatedOn = DateTime.Now,
                        CreatedBy = "Beatrice"

                    }
                );
                context.SaveChanges();

                context.Orders.AddOrUpdate(
                    p => p.Id,
                    new Order
                    {
                        CreatedOn = DateTime.Now,
                        CreatedBy = "Beatrice",
                        StartAddress = "B-dul Maniu nr.154-156",
                        DeliveryAddress = "B-dul Unirii nr.13",
                        Client = context.Clients.FirstOrDefault()
                    }
                );

                context.Orders.AddOrUpdate(
                    p => p.Id,
                    new Order
                    {
                        CreatedOn = DateTime.Now,
                        CreatedBy = "Beatrice",
                        StartAddress = "B-dul Maniu nr.154-156",
                        DeliveryAddress = "B-dul Unirii nr.13",
                        Client = context.Clients.FirstOrDefault()
                    });
                //context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }
    }
}
