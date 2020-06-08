using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballManagerApp.EntityFramework;
using FootballManagerApp.Models;
using FootballManagerApp.Repositories.Interfaces;

namespace FootballManagerApp.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly ITrainingRepository repository;
        private readonly ITrainerRepository trainer;
        private readonly ITeamRepository team;

        public TrainingsController(ITrainingRepository _repository, ITrainerRepository _trainer, ITeamRepository _team)
        {
            repository = _repository;
            trainer = _trainer;
            team = _team;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            var trainings = repository.GetAllAsync();
            return View(await trainings);
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await repository.GetAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType");
            ViewData["TrainerId"] = new SelectList(trainer.GetAll(), "Id", "Surname");
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
                repository.Add(training);
                await repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", training.TeamId);
            ViewData["TrainerId"] = new SelectList(trainer.GetAll(), "Id", "Surname", training.TrainerId);
            return View(training);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await repository.GetAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", training.TeamId);
            ViewData["TrainerId"] = new SelectList(trainer.GetAll(), "Id", "Surname", training.TrainerId);
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
                    repository.Update(training);
                    await repository.SaveAsync();
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
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", training.TeamId);
            ViewData["TrainerId"] = new SelectList(trainer.GetAll(), "Id", "Surname", training.TrainerId);
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await repository.GetAsync(id);
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
            var training = await repository.GetAsync(id);
            repository.Delete(training);
            await repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            return repository.GetAll().Any(e => e.Id == id);
        }
    }
}
