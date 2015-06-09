namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitedDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leads", "VisitedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leads", "VisitedDate", c => c.DateTime(nullable: false));
        }
    }
}
