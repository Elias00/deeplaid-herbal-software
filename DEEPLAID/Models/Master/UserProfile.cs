using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEEPLAID.Models.Master
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Remarks { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<SiteMenu> SiteMenus { get; set; }


    }
}