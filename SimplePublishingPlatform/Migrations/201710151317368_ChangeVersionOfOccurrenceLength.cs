namespace SimplePublishingPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVersionOfOccurrenceLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProblemInfo", "VersionOfOccurrence", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProblemInfo", "VersionOfOccurrence", c => c.String(maxLength: 10));
        }
    }
}
