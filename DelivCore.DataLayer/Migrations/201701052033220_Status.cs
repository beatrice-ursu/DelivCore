namespace DelivCore.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.String());
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Deliveries", "EstimatedDelivery", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Orders", "IsProcessed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "IsProcessed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Deliveries", "EstimatedDelivery", c => c.DateTime(nullable: false));
            DropColumn("dbo.People", "Discriminator");
            DropColumn("dbo.Orders", "Status");
        }
    }
}
