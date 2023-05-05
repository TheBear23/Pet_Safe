using System.Text;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pet_Safe.Data;
using Pet_Safe.Models;

namespace Pet_Safe.Controllers
{
    public class PlantController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PlantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Plant> plants = new List<Plant>();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ntnic\Desktop\LC101C#\Projects&Assignments\Pet_Safe\Pet_Safe\wwwroot\plants\plants.csv");
                foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                Plant plant = new Plant()
                {
                    Name = fields[0],
                    IsToxic = bool.Parse(fields[1])
                };
                plants.Add(plant);
            }
            return View(plants);
        }
        public IActionResult DeletePlants(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }

            var plant = _context.Plants.Find(id);
            if (plant == null)
            {
                return NotFound();
            }
            return View(plant);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var plant = _context.Plants.Find(id);
            _context.Plants.Remove(plant);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

