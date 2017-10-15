namespace SimplePublishingPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProblemInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProblemInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionOfOccurrence = c.String(maxLength: 10),
                        Customer = c.String(maxLength: 50),
                        ProblemDetail = c.String(maxLength: 1000),
                        Submitter = c.String(maxLength: 50),
                        ProblemState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProblemInfo");
        }
    }
}
