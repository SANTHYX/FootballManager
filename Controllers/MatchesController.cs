using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballManagerApp.Models;
using FootballManagerApp.Repositories.Interfaces;

namespace FootballManagerApp.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IMatchRepository repository;
        private readonly ITeamRepository team;

        public MatchesController(IMatchRepository _repository, ITeamRepository _team)
        {
            repository = _repository;
            team = _team;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var matches = repository.GetAllAsync();
            return View(await matches);
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await repository.GetAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Versus,MachType,DateOfMatch,TeamId")] Match match)
        {
            if (ModelState.IsValid)
            {
                repository.Add(match);
                await repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", match.TeamId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await repository.FindsAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", match.TeamId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Versus,MachType,DateOfMatch,TeamId")] Match match)
        {
            var exist = await repository.GetAllAsync();

            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(match);
                    await repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            ViewData["TeamId"] = new SelectList(team.GetAll(), "Id", "TeamType", match.TeamId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await repository.GetAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await repository.FindsAsync(id);
            repository.Delete(match);
            await repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool MatchExists(int id)
        {
            return repository.GetAll().Any(e => e.Id == id);
        }
    }
}
