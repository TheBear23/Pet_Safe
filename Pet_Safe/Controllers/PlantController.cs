using System;
using System.IO;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Pet_Safe.Data;
using Pet_Safe.Models;

namespace Pet_Safe.Controllers
{
    public class PlantController : Controller
    {
        private ApplicationDbContext context;

        public PlantController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<Plants> plants = context.Plant.ToList();
            return View(plants);
        }
    }
}
