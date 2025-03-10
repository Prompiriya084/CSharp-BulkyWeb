using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Domain.Models
{
    public class Authorization
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        //// Many-to-Many Relationship with UserAuth
        //public ICollection<UserAuthorize> UserAuthorizes { get; set; }
    }
}
