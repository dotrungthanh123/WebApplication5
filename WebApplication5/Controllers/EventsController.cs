using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Allevents()
        {
            return View();
        }
    }
}
