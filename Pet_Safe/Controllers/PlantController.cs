using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Pet_Safe.Data;

namespace Pet_Safe.Controllers
{
    public class PlantController : Controller
    {
        private readonly ApplicationDbContext? context;
        private readonly ApplicationDbContext? dbContext;

        public PlantController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
