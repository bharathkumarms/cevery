namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoGenAppNo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leads", "ApplicationNumber", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
        }
    }
}
