namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteNumberNotMandatory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leads", "QuotationNumber", c => c.Int());
            AlterColumn("dbo.Leads", "ProductName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leads", "ProductName", c => c.String());
            AlterColumn("dbo.Leads", "QuotationNumber", c => c.Int(nullable: false));
        }
    }
}
