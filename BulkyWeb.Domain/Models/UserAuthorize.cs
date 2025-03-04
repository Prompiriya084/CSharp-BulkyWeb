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
        //[ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
        //[ForeignKey("Authorization")]
        public string AuthorizationId { get; set; }
        public Authorization Authorization { get; set; }
    }
}
