namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "VisitedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Leads", "CustomerDepartment", c => c.String());
            AddColumn("dbo.Leads", "CustomerDesignation", c => c.String());
            AddColumn("dbo.Leads", "CustomerContactName", c => c.String());
            AddColumn("dbo.Leads", "CustomerContactNumber", c => c.String());
            AddColumn("dbo.Leads", "CustomerContactEmailId", c => c.String());
            AlterColumn("dbo.Leads", "ApplicationNumber", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Leads", "QuotationNumber", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Leads");
            AddPrimaryKey("dbo.Leads", "ApplicationNumber");
            DropColumn("dbo.Leads", "SNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leads", "SNo", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Leads");
            AddPrimaryKey("dbo.Leads", "SNo");
            AlterColumn("dbo.Leads", "QuotationNumber", c => c.Int());
            AlterColumn("dbo.Leads", "ApplicationNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Leads", "CustomerContactEmailId");
            DropColumn("dbo.Leads", "CustomerContactNumber");
            DropColumn("dbo.Leads", "CustomerContactName");
            DropColumn("dbo.Leads", "CustomerDesignation");
            DropColumn("dbo.Leads", "CustomerDepartment");
            DropColumn("dbo.Leads", "VisitedDate");
        }
    }
}
