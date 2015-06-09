namespace CEvery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        SNo = c.Int(nullable: false, identity: true),
                        ApplicationNumber = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                        Indicator = c.String(),
                        QuotationNumber = c.Int(nullable: false),
                        ProductName = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentPath = c.String(),
                        EmployeeName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.SNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Leads");
        }
    }
}
