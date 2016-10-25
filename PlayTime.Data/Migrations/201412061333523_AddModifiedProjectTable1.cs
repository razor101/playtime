namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModifiedProjectTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "Price", c => c.Double(nullable: false, defaultValue: 0d));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "Price");
        }
    }
}
