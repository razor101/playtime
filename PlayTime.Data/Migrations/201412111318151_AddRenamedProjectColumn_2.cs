namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRenamedProjectColumn_2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectUser", newName: "ProjectAssignedUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProjectAssignedUsers", newName: "ProjectUser");
        }
    }
}
