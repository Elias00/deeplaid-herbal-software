namespace DEEPLAID.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileSiteMenu_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfileSiteMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserProfileId = c.Int(nullable: false),
                        SiteMenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfileSiteMenus");
        }
    }
}
