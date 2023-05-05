using System;
using Microsoft.AspNetCore.Mvc;
using Pet_Safe.Data;

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
