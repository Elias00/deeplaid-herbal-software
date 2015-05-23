namespace DEEPLAID.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteMenuModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Group = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        ControllerName = c.String(nullable: false),
                        ControllerAction = c.String(nullable: false),
                        MenuPriority = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SiteMenus");
        }
    }
}
