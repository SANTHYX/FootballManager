using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballManagerApp.EntityFramework;
using FootballManagerApp.Models;

namespace FootballManagerApp.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly FootballDbContext _context;

        public TrainingsController(FootballDbContext context)
        {
            _context = context;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            var footballDbContext = _context.Training.Include(t => t.Team).Include(t => t.Trainer);
            return View(await footballDbContext.ToListAsync());
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training
                .Include(t => t.Team)
                .Include(t => t.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamType");
            ViewData["TrainerId"] = new SelectList(_context.Trainer, "Id", "Surname");
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,BeginOf,EndOf,TeamId,TrainerId")] Training training)
        {
            if (ModelState.IsValid)
            {
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamType", training.TeamId);
            ViewData["TrainerId"] = new SelectList(_context.Trainer, "Id", "Surname", training.TrainerId);
            return View(training);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamType", training.TeamId);
            ViewData["TrainerId"] = new SelectList(_context.Trainer, "Id", "Surname", training.TrainerId);
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,BeginOf,EndOf,TeamId,TrainerId")] Training training)
        {
            if (id != training.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.Id))
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
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamType", training.TeamId);
            ViewData["TrainerId"] = new SelectList(_context.Trainer, "Id", "Surname", training.TrainerId);
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training
                .Include(t => t.Team)
                .Include(t => t.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var training = await _context.Training.FindAsync(id);
            _context.Training.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            return _context.Training.Any(e => e.Id == id);
        }
    }
}
