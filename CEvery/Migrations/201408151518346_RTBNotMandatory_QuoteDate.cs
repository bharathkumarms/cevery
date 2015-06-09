namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RTBNotMandatory_QuoteDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "QuoteDate", c => c.DateTime());
            AlterColumn("dbo.Leads", "PageContent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leads", "PageContent", c => c.String(nullable: false));
            DropColumn("dbo.Leads", "QuoteDate");
        }
    }
}
