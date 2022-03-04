namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RMSProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registrations");
        }
    }
}
