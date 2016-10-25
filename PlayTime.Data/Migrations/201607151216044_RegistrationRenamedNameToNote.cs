namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationRenamedNameToNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registration", "Note", c => c.String());
            DropColumn("dbo.Registration", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registration", "Name", c => c.String());
            DropColumn("dbo.Registration", "Note");
        }
    }
}
