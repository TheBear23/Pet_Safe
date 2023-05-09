using System.Text;
using System.IO;
using System.Collections.Generic;
using System; 
using Microsoft.AspNetCore.Mvc;
using Pet_Safe.Data;
using Pet_Safe.Models;

namespace Pet_Safe.Controllers
{
    public class PlantController : Controller
    {
        private readonly PlantDbContext _context;
        public PlantController(PlantDbContext context)
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
                    IsToxic = bool.Parse(fields[2])
                };
                plants.Add(plant);
            }
            return View(plants);
        }

        public IActionResult Toxicity(string type, string animal)
        {
            List<Plant> plants = new List<Plant>();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ntnic\Desktop\LC101C#\Projects&Assignments\Pet_Safe\Pet_Safe\wwwroot\plants\plants.csv");
            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                if (fields[1] == type)
                {
                    Plant plant = new Plant()
                    {
                        Name = fields[0],
                        IsToxic = bool.Parse(fields[2])
                    };
                    plants.Add(plant);
                }
            }

            foreach (Plant plant in plants)
            {
                if (plant.IsToxic == true && animal == "Cat")
                {
                    ViewBag.Message = plant.Name + "Is TOXIC to cats!! Avoid at all cost!!";
                    return View();
                }
                else if (plant.IsToxic == true && animal == "Dog")
                {
                    ViewBag.Message = plant.Name + "Is TOXIC to dogs!! Avoid at all cost!!";
                    return View();
                }
                else if (plant.IsToxic == true && animal == "Rabbit")
                {
                    ViewBag.Message = plant.Name + "Is TOXIC to dogs!! Avoid at all cost!!";
                    return View();
                }
            }

            ViewBag.Message = "SAFE!! Non-Toxic!!";
            return View();
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

        [HttpPost]
        public IActionResult AddPlant(Plant plant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }

        public IActionResult AddPlant()
        {
            return View();
        }
    }
}

