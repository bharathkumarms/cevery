namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RTB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "PageContent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leads", "PageContent");
        }
    }
}
