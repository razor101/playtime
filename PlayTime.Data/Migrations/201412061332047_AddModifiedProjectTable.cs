namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModifiedProjectTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "IsFixed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Project", "StartDate", c => c.DateTime());
            AddColumn("dbo.Project", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "EndDate");
            DropColumn("dbo.Project", "StartDate");
            DropColumn("dbo.Project", "IsFixed");
        }
    }
}
