namespace DelivCore.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderOffers",
                c => new
                    {
                        OrderOfferId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        StartAddress = c.String(nullable: false),
                        DeliveryAddress = c.String(nullable: false),
                        NumberOfPackages = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderOfferId);
            
            AddColumn("dbo.Orders", "IsProcessed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsProcessed");
            DropTable("dbo.OrderOffers");
        }
    }
}
