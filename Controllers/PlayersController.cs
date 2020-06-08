using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballManagerApp.EntityFramework;
using FootballManagerApp.Models;
using FootballManagerApp.Repositories;
using FootballManagerApp.Repositories.Interfaces;

namespace FootballManagerApp.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerRepository repository;

        private readonly ITeamRepository team;

        public PlayersController(IPlayerRepository _repository, ITeamRepository _team)
        {
            repository = _repository;
            team = _team;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var players = await repository.GetAllAsync();
            return View(players);
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await repository.GetAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Number,TeamId,Goal,Assist,RedCard,YellowCard,Position")] Player player)
        {
            if (ModelState.IsValid)
            {
                repository.Add(player);
                await repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await repository.GetAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Number,TeamId,Goal,Assist,RedCard,YellowCard,Position")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }
            var existplayer = await repository.GetAllAsync();
            var exist = existplayer.Any(x => x.Id == player.Id);

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(player);
                    await repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await repository.GetAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await repository.GetAsync((int?)id);
            repository.Delete(player);
            await repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PlayerExists(int id)
        {
            return repository.GetAll().Any(x => x.Id == id);
        }
    }
}
