namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTaskStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeactivated = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Task", "StatusText", c => c.String());
            AddColumn("dbo.Task", "HasFlatEstimate", c => c.Boolean(nullable: false));
            AddColumn("dbo.Task", "EstimateFlat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Task", "EstimateOptimistic", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Task", "EstimateRealistic", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Task", "EstimatePessimistic", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "EstimatePessimistic");
            DropColumn("dbo.Task", "EstimateRealistic");
            DropColumn("dbo.Task", "EstimateOptimistic");
            DropColumn("dbo.Task", "EstimateFlat");
            DropColumn("dbo.Task", "HasFlatEstimate");
            DropColumn("dbo.Task", "StatusText");
            DropTable("dbo.TaskStatus");
        }
    }
}
