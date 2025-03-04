using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Domain.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public string Role {  get; set; }
        public string Position { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? DeletedDate {  get; set; }
        // 🔹 Foreign Key for Category
        [ForeignKey("UserAuthen")]
        public int UserAuthenId { get; set; }
        // 🔹 Navigation Property
        public UserAuthen UserAuthen { get; set; }
        //// 🔹 Foreign Key for Category
        //[ForeignKey("UserAuthorize")]
        //public int UserAuthorizeId { get; set; }
        // 🔹 Navigation Property
        public ICollection<UserAuthorize> UserAuthorize { get; set; }
    }
}
