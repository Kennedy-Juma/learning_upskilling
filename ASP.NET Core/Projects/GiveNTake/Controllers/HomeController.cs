using Microsoft.AspNetCore.Mvc;

namespace GiveNTake.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
