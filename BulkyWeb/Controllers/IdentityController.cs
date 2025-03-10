using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class IdentityController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
