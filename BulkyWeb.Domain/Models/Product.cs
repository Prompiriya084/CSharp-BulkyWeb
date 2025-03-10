using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb.Domain.Models
{
    [Table("Product", Schema = "dbo")]
    //[PrimaryKey(nameof(DCSR_ID))]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(200, ErrorMessage = "Feild name is required 200 digits.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a price.")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public DateTime? DeletedDate { get; set; }

        // 🔹 Foreign Key for Category
        public int CategoryId { get; set; }
        // 🔹 Navigation Property
        public Category Category { get; set; }
    }
}
