namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsQuoteStage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "IsQuoteStage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leads", "IsQuoteStage");
        }
    }
}
