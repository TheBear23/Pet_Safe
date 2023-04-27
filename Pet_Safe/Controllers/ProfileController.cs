using Microsoft.AspNetCore.Mvc;

namespace Pet_Safe.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
