using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Domain.Models
{
    public class UserAuthorize
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserAuthen")]
        public int UserAuthenId { get; set; }
        public UserAuthen UserAuthen { get; set; }
        [ForeignKey("Authorization")]
        public int AuthorizationId { get; set; }
        public Authorization Authorization { get; set; }
    }
}
