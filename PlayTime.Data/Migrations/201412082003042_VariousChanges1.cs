namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VariousChanges1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectUser",
                c => new
                    {
                        AssignedUsers = c.Guid(nullable: false),
                        AssignedProjects = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AssignedUsers, t.AssignedProjects })
                .ForeignKey("dbo.Project", t => t.AssignedUsers, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.AssignedProjects, cascadeDelete: true)
                .Index(t => t.AssignedUsers)
                .Index(t => t.AssignedProjects);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectUser", "AssignedProjects", "dbo.User");
            DropForeignKey("dbo.ProjectUser", "AssignedUsers", "dbo.Project");
            DropIndex("dbo.ProjectUser", new[] { "AssignedProjects" });
            DropIndex("dbo.ProjectUser", new[] { "AssignedUsers" });
            DropTable("dbo.ProjectUser");
        }
    }
}
