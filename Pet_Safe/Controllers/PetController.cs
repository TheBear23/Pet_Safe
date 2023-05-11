using Microsoft.AspNetCore.Mvc;

namespace Pet_Safe.Controllers
{
    public class Pets : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
