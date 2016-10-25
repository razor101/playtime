namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdjustTaskTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "UserId");
        }
    }
}
