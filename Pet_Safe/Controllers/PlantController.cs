using Microsoft.AspNetCore.Mvc;

namespace Pet_Safe.Controllers
{
    public class PlantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
