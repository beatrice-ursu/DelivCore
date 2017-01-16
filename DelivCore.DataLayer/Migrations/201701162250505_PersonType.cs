namespace DelivCore.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PersonType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PersonType");
        }
    }
}
