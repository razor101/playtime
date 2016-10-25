namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegistrationAdjustments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registration", "StartTime", c => c.DateTime());
            AddColumn("dbo.Registration", "EndTime", c => c.DateTime());
            AddColumn("dbo.Registration", "IsInvoiced", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registration", "IsInvoiced");
            DropColumn("dbo.Registration", "EndTime");
            DropColumn("dbo.Registration", "StartTime");
        }
    }
}
