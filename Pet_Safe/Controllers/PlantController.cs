using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Pet_Safe.Data;

namespace Pet_Safe.Controllers
{
    public class PlantController : Controller
    {
        private PlantDbContext context;

        public PlantController(PlantDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
