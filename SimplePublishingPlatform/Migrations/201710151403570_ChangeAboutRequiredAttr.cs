namespace SimplePublishingPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAboutRequiredAttr : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SoftwareVersion", new[] { "VersionName" });
            AlterColumn("dbo.ProblemInfo", "Customer", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ProblemInfo", "ProblemDetail", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.ProblemInfo", "Submitter", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SoftwareVersion", "VersionName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SoftwareVersion", "Description", c => c.String(nullable: false, maxLength: 500));
            CreateIndex("dbo.SoftwareVersion", "VersionName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.SoftwareVersion", new[] { "VersionName" });
            AlterColumn("dbo.SoftwareVersion", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.SoftwareVersion", "VersionName", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProblemInfo", "Submitter", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProblemInfo", "ProblemDetail", c => c.String(maxLength: 1000));
            AlterColumn("dbo.ProblemInfo", "Customer", c => c.String(maxLength: 50));
            CreateIndex("dbo.SoftwareVersion", "VersionName", unique: true);
        }
    }
}
