using System;
using Microsoft.AspNetCore.Mvc;
using Pet_Safe.Data;

namespace Pet_Safe.Controllers
{
    public class ProfileController : Controller
    {
        private readonly PlantDbContext _context;

        public ProfileController(PlantDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}

