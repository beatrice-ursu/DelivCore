namespace DelivCore.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderOffers", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderOffers", "Description");
        }
    }
}
