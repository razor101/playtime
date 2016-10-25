namespace PlayTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAndAdjustPresetTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preset",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        UserId = c.String(),
                        CustomerId = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        IsDeactivated = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        User_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Id)
                .ForeignKey("dbo.Project", t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.User", t => t.User_Id1)
                .Index(t => t.Id)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preset", "User_Id1", "dbo.User");
            DropForeignKey("dbo.Preset", "User_Id", "dbo.User");
            DropForeignKey("dbo.Preset", "Id", "dbo.Project");
            DropForeignKey("dbo.Preset", "Id", "dbo.Customer");
            DropIndex("dbo.Preset", new[] { "User_Id1" });
            DropIndex("dbo.Preset", new[] { "User_Id" });
            DropIndex("dbo.Preset", new[] { "Id" });
            DropTable("dbo.Preset");
        }
    }
}
