namespace SimplePublishingPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubmitTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProblemInfo", "SubmitTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProblemInfo", "SubmitTime");
        }
    }
}
