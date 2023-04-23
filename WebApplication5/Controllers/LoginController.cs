using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
