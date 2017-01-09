namespace DelivCore.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        InvoiceAddress = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstimatedDistance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartAddress = c.String(nullable: false),
                        DeliveryAddress = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Age = c.Int(nullable: false),
                        Username = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstimatedDelivery = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                        Courier_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Courier_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Courier_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.DeliveryOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.Time(nullable: false, precision: 7),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                        Courier_Id = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Courier_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Courier_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeliveryOffers", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.DeliveryOffers", "Courier_Id", "dbo.People");
            DropForeignKey("dbo.Deliveries", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Deliveries", "Courier_Id", "dbo.People");
            DropForeignKey("dbo.Packages", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.DeliveryOffers", new[] { "Order_Id" });
            DropIndex("dbo.DeliveryOffers", new[] { "Courier_Id" });
            DropIndex("dbo.Deliveries", new[] { "Order_Id" });
            DropIndex("dbo.Deliveries", new[] { "Courier_Id" });
            DropIndex("dbo.Packages", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropTable("dbo.DeliveryOffers");
            DropTable("dbo.Deliveries");
            DropTable("dbo.People");
            DropTable("dbo.Packages");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}
