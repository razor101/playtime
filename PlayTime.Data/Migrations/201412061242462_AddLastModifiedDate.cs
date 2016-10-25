namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastModifiedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "LastModifiedDate", c => c.DateTime());
            AddColumn("dbo.Project", "LastModifiedDate", c => c.DateTime());
            AddColumn("dbo.Task", "LastModifiedDate", c => c.DateTime());
            AddColumn("dbo.Registration", "LastModifiedDate", c => c.DateTime());
            AddColumn("dbo.User", "LastModifiedDate", c => c.DateTime());
            AddColumn("dbo.Preset", "LastModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preset", "LastModifiedDate");
            DropColumn("dbo.User", "LastModifiedDate");
            DropColumn("dbo.Registration", "LastModifiedDate");
            DropColumn("dbo.Task", "LastModifiedDate");
            DropColumn("dbo.Project", "LastModifiedDate");
            DropColumn("dbo.Customer", "LastModifiedDate");
        }
    }
}
