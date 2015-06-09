namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoGenAppNoRename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "ApplicationNo", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Leads");
            AddPrimaryKey("dbo.Leads", "ApplicationNo");
            DropColumn("dbo.Leads", "ApplicationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leads", "ApplicationNumber", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Leads");
            AddPrimaryKey("dbo.Leads", "ApplicationNumber");
            DropColumn("dbo.Leads", "ApplicationNo");
        }
    }
}
