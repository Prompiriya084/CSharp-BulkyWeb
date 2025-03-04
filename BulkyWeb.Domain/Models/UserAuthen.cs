using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Domain.Models
{
    public class UserAuthen
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        // Many-to-Many Relationship with UserAuthorization (Roles)
        //public ICollection<UserAuthorize> UserAuthorizes { get; set; } = new List<UserAuthorize>();
        // One-to-One Relationship with UserInfo
        //public UserInfo UserInfo { get; set; } // Navigation Property
    }
}
