using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEEPLAID.Models.Master
{
    public class SiteMenu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Group { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string ControllerAction { get; set; }
        [Required]
        public int MenuPriority { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<UserProfile> UserProfiles { get; set; }
    }
}