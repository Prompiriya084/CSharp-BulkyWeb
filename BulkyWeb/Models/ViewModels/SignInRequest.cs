using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models.ViewModels
{
    public class SignInRequest
    {
        [Required(ErrorMessage = "Please enter a name.")]
        public string email {  get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        public string password { get; set; }
    }
}
