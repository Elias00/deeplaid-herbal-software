using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEEPLAID.Models.Master
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LoginId { get; set; }
        
        [Required]
        public string Password { get; set; }

        public DateTime CreateDateTime { get; set; }
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public bool IsValid(string loginId, string password)
        {
            DeeplaidDbContext db = new DeeplaidDbContext();
            var user = db.Users.FirstOrDefault(s => s.LoginId == loginId && s.Password == password);

            {
                if (user == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}