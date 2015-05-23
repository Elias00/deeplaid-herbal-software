namespace DEEPLAID.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserProfileId", c => c.Int(nullable: true));
            CreateIndex("dbo.Users", "UserProfileId");
            AddForeignKey("dbo.Users", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Users", new[] { "UserProfileId" });
            DropColumn("dbo.Users", "UserProfileId");
            DropTable("dbo.UserProfiles");
        }
    }
}
