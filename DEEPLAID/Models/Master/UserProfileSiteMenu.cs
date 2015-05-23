using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEEPLAID.Models.Master
{
    public class UserProfileSiteMenu
    {
        [Key]
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int SiteMenuId { get; set; }
        public virtual IEnumerable<SiteMenu> SiteMenus { get; set; }
        public virtual IEnumerable<UserProfile> UserProfiles { get; set; }

    }
}