namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTaskStatusTable_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "TaskStatusId", c => c.Guid(nullable: false));
            AddColumn("dbo.TaskStatus", "Task_Id", c => c.Guid());
            CreateIndex("dbo.TaskStatus", "Task_Id");
            AddForeignKey("dbo.TaskStatus", "Task_Id", "dbo.Task", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskStatus", "Task_Id", "dbo.Task");
            DropIndex("dbo.TaskStatus", new[] { "Task_Id" });
            DropColumn("dbo.TaskStatus", "Task_Id");
            DropColumn("dbo.Task", "TaskStatusId");
        }
    }
}
