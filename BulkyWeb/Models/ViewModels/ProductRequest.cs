using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models.ViewModels
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(200, ErrorMessage = "Feild name is required 200 digits.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a price.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
