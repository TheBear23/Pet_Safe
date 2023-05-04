using System;
using System.IO;
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
            return View();
        }
    }
}
