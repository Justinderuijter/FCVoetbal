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
    public class TeamController : Controller
    {
        private readonly VoetbalContext _context;
        public TeamController(VoetbalContext context) 
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(new ListViewModel<Team>(await _context.Teams.ToListAsync()));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naam")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            TeamViewModel vm = new TeamViewModel()
            {
                Naam = team.Naam
            };

            return View(vm);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Team team = await _context.Teams.FirstOrDefaultAsync(m => m.ID == id);
            //var kl = await _context.Klanten.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }


            return View(new TeamViewModel(team.Naam));
        }

        //POST: (Localhost)/Klant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.Include(t => t.UitMatchen).Include(t => t.ThuisMatchen).FirstOrDefaultAsync(m => m.ID == id);
            if (team != null)
            {
                CascadeDelete(team);
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return View(new TeamViewModel(team.Naam));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
                [Bind("Naam")] Team team)
        {
            team.ID = id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.ID))
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

            return View(new EditTeamViewModel(id, team.Naam));
        }

        private bool TeamExists(int id)
        {
            Team team = _context.Teams.Find(id);
            return team != null;
        }

        private void CascadeDelete(Team team)
        {
            foreach (var match in team.ThuisMatchen)
            {
                _context.Matches.Remove(match);

            }
            foreach (var match in team.UitMatchen)
            {
                _context.Matches.Remove(match);

            }
        }
    }
}
