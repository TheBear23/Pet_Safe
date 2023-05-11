using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet_Safe.Data;
using Pet_Safe.Models;

namespace Pet_Safe.Controllers
{
    public class PlantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plants'
        [Authorize]
             public async Task<IActionResult> Index(string searchString)
            {
                if (_context.Plants == null)
                {
                    return Problem("Entity set 'MvcPlantsContext.Plants'  is null.");
                }
                var plant = from p in _context.Plants
                            select p;
                if (!String.IsNullOrEmpty(searchString))
                {
                    plant = plant.Where(s => s.Name!.Contains(searchString));
                }
                return View(await plant.ToListAsync());
            }

            /*              return _context.Plants != null ? 
                                      View(await _context.Plants.ToListAsync()) :
                                      Problem("Entity set 'ApplicationDbContext.Plants'  is null.");
        }*/

        // GET: Plants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plants = await _context.Plants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plants == null)
            {
                return NotFound();
            }

            return View(plants);
        }

        // GET: Plants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,ToxicTo")] Plants plants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plants);
        }

        // GET: Plants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plants = await _context.Plants.FindAsync(id);
            if (plants == null)
            {
                return NotFound();
            }
            return View(plants);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,ToxicTo")] Plants plants)
        {
            if (id != plants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantsExists(plants.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(plants);
        }

        // GET: Plants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plants == null)
            {
                return NotFound();
            }

            var plants = await _context.Plants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plants == null)
            {
                return NotFound();
            }

            return View(plants);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Plants'  is null.");
            }
            var plants = await _context.Plants.FindAsync(id);
            if (plants != null)
            {
                _context.Plants.Remove(plants);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantsExists(int id)
        {
          return (_context.Plants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
