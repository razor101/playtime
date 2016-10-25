namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdjustTaskTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Task", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Task", "UserId");
            AddForeignKey("dbo.Task", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "UserId", "dbo.User");
            DropIndex("dbo.Task", new[] { "UserId" });
            AlterColumn("dbo.Task", "UserId", c => c.String());
        }
    }
}
