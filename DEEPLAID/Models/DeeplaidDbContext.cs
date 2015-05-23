using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DEEPLAID.Models.Master;

namespace DEEPLAID.Models
{
    public class DeeplaidDbContext:DbContext
    {
        public DeeplaidDbContext(): base("DeeplaidConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<SiteMenu> SiteMenus { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserProfileSiteMenu> UserProfileSiteMenus { get; set; }
    }
}