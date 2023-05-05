using System;
using Microsoft.AspNetCore.Mvc;
using Pet_Safe.Data;
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
