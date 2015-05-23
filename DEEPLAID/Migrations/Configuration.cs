using System.Collections.Generic;
using DEEPLAID.Models.Master;

namespace DEEPLAID.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DEEPLAID.Models.DeeplaidDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DEEPLAID.Models.DeeplaidDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //var users = new List<User>
            //{
            //    new User(){Name = "Administrator",CreateDateTime = DateTime.Parse("2015/05/15 22:30:00"),LoginId = "admin",Password = "123"}
            //};
            //users.ForEach(s => context.Users.AddOrUpdate(s));
            //context.SaveChanges();

            //var siteMenus = new List<SiteMenu>
            //{
            //    new SiteMenu(){Group = "Master",Name = "Users",ControllerName = "User",ControllerAction = "Index",Remarks = "System reserved"}
            //};
            //siteMenus.ForEach(s => context.SiteMenus.AddOrUpdate(s));
            //context.SaveChanges();

            //var userProfiles = new List<UserProfile>
            //{
            //    new UserProfile(){Name = "Administrators",Remarks = "Reserved"},
            //    new UserProfile(){Name = "Users",Remarks = "Reserved"},
            //};
            //userProfiles.ForEach(s => context.UserProfiles.AddOrUpdate(s));
            //context.SaveChanges();
        }
    }
}
