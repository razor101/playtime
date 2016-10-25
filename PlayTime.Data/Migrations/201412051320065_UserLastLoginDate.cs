namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLastLoginDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "LastLoginDate", c => c.DateTime(true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "LastLoginDate");
        }
    }
}
