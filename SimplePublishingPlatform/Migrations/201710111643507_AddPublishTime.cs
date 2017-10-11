namespace SimplePublishingPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublishTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SoftwareVersion", "PublishTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SoftwareVersion", "PublishTime");
        }
    }
}
