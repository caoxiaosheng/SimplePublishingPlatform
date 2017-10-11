namespace SimplePublishingPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoftwareVersion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionName = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        DetailPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.VersionName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SoftwareVersion", new[] { "VersionName" });
            DropTable("dbo.SoftwareVersion");
        }
    }
}
