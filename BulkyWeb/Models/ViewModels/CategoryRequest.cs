using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models.ViewModels
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(200, ErrorMessage = "Feild name is required 200 digits.")]
        public string Name { get; set; }
    }
}
