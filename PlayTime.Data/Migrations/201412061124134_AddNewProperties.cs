namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Task", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Registration", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "CreatedDate");
            DropColumn("dbo.Registration", "CreatedDate");
            DropColumn("dbo.Task", "CreatedDate");
            DropColumn("dbo.Project", "CreatedDate");
        }
    }
}
