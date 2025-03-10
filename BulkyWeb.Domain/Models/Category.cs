using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Domain.Models
{
    [Table("Category", Schema = "dbo")]
    //[PrimaryKey(nameof(DCSR_ID))]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(200, ErrorMessage = "Feild name is required 200 digits.")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        // Navigation Property (One-to-Many Relationship)
        public ICollection<Product> Products { get; set; }
    }
}
