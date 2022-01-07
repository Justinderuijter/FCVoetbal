using FCVoetbal.Data;
using FCVoetbal.Models;
using FCVoetbal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TrainingController : Controller
    {
        private readonly VoetbalContext _context;
        public TrainingController(VoetbalContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(new ListViewModel<Training>(await _context.Trainingen.Include(t => t.Team).ToListAsync()));
        }

        public async Task<IActionResult> Create()
        {
            return View(new CreateTrainingViewModel(await _context.Teams.ToListAsync(), DateTime.Now));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Plaats,Datum,TeamID")] Training training)
        {
            //Kijk of training wel is ingevuld.
            await ValidateTeam(training.TeamID);

            if (ModelState.IsValid)
            {
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(new CreateTrainingViewModel(await _context.Teams.ToListAsync(), training.Datum, training.Plaats, training.TeamID));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Training training = await _context.Trainingen.FirstOrDefaultAsync(m => m.ID == id);
            if (training == null)
            {
                return NotFound();
            }


            return View(new TrainingViewModel(training.Plaats, training.Datum, training.TeamID));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Training training = await _context.Trainingen.FindAsync(id);
            _context.Trainingen.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Training training = await _context.Trainingen.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return View(new EditTrainingViewModel(await _context.Teams.ToListAsync(), training.ID, training.Plaats, training.Datum, training.TeamID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
                [Bind("Plaats,Datum,TeamID")] Training training)
        {
            training.ID = id;

            //Kijk of training wel is ingevuld.
            await ValidateTeam(training.TeamID);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.ID))
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

            return View(new EditTrainingViewModel(await _context.Teams.ToListAsync(), training.ID, training.Plaats, training.Datum, training.TeamID));
        }

        private bool TrainingExists(int id)
        {
            Training training = _context.Trainingen.Find(id);
            return training != null;
        }

        private async Task<bool> IsTeamValid(int teamId)
        {
            if (teamId <= 0)
            {
                return false;
            }
            return await _context.Teams.FindAsync(teamId) != null;
        }

        private async Task ValidateTeam(int teamId)
        {
            if (await IsTeamValid(teamId)) return;

            ModelState.AddModelError("TeamID", "Team is een verplicht veld!");
        }
    }
}
