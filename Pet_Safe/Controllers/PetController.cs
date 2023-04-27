using Microsoft.AspNetCore.Mvc;

namespace Pet_Safe.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
