namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerCreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "CreatedDate");
        }
    }
}
