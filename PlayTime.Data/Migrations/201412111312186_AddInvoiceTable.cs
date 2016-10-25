namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        IsDeactivated = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Id)
                .ForeignKey("dbo.Project", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Task", "Invoice_Id", c => c.Guid());
            CreateIndex("dbo.Task", "Invoice_Id");
            AddForeignKey("dbo.Task", "Invoice_Id", "dbo.Invoice", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "Invoice_Id", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "Id", "dbo.Project");
            DropForeignKey("dbo.Invoice", "Id", "dbo.Customer");
            DropIndex("dbo.Invoice", new[] { "Id" });
            DropIndex("dbo.Task", new[] { "Invoice_Id" });
            DropColumn("dbo.Task", "Invoice_Id");
            DropTable("dbo.Invoice");
        }
    }
}
