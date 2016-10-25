namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsDeactivated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CustomerId = c.Guid(nullable: false),
                        IsDeactivated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ProjectId = c.Guid(nullable: false),
                        IsDeactivated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Registration",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        UserId = c.String(maxLength: 128),
                        TaskId = c.Guid(nullable: false),
                        IsDeactivated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Task", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                        IsDeactivated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registration", "UserId", "dbo.User");
            DropForeignKey("dbo.Registration", "TaskId", "dbo.Task");
            DropForeignKey("dbo.Task", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Registration", new[] { "TaskId" });
            DropIndex("dbo.Registration", new[] { "UserId" });
            DropIndex("dbo.Task", new[] { "ProjectId" });
            DropIndex("dbo.Project", new[] { "CustomerId" });
            DropTable("dbo.User");
            DropTable("dbo.Registration");
            DropTable("dbo.Task");
            DropTable("dbo.Project");
            DropTable("dbo.Customer");
        }
    }
}
