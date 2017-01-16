namespace DelivCore.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonTo = c.String(nullable: false),
                        PersonFrom = c.String(nullable: false),
                        MessageBody = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
