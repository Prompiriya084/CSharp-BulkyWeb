using BulkyWeb.Domain.Models;

namespace BulkyWeb.Models.ViewModels
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Surname {  get; set; }
        public List<string> AuthorizeId { get; set; }
    }
}
