using Microsoft.AspNetCore.Mvc;

namespace Asteroids.Controllers
{
    public class AsteroidsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
