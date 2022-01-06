using FCVoetbal.Data;
using FCVoetbal.Models;
using FCVoetbal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Controllers
{
    public class MatchController : Controller
    {
        private readonly VoetbalContext _context;
        public MatchController(VoetbalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(new ListViewModel<Match>(await _context.Matches.Include(m => m.ThuisTeam).Include(m => m.UitTeam).ToListAsync()));
        }

        public async Task<IActionResult> Create()
        {
            return View(new CreateMatchViewModel(await _context.Teams.ToListAsync(), DateTime.Today));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMatchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int thuisTeamId = 0;
                int uitTeamId = 0;
                if (vm.ThuisTeam != null)
                {
                    thuisTeamId = vm.ThuisTeam.ID;
                }
                if (vm.UitTeam != null)
                {
                    uitTeamId = vm.UitTeam.ID;
                }

                Match match = new Match()
                {
                    Plaats = vm.Plaats,
                    Datum = vm.Datum,
                    ThuisTeamId = thuisTeamId,
                    UitTeamId = uitTeamId,
                    ThuisDoelpunten = vm.ThuisDoelpunten,
                    UitDoelpunten = vm.UitDoelpunten
                };
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Match match = await _context.Matches.Include(m => m.ThuisTeam).Include(m => m.UitTeam).FirstOrDefaultAsync(m => m.ID == id);
            if (match == null)
            {
                return NotFound();
            }


            return View(new MatchViewModel(match.Datum, match.Plaats, match.ThuisTeam, match.UitTeam, match.ThuisDoelpunten, match.UitDoelpunten));
        }

        //POST: (Localhost)/Klant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Speler speler = await _context.Spelers.FindAsync(id);

            if (speler == null)
            {
                return NotFound();
            }

            return View(new EditSpelerViewModel(await _context.Teams.ToListAsync(), speler.ID, speler.Voornaam, speler.Achternaam, speler.Rugnummer, speler.Doelpunten, speler.TeamID));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
                [Bind("Voornaam,Achternaam,Rugnummer,Doelpunten,TeamID")] Speler speler)
        {
            speler.ID = id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(speler.ID))
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

            return View(new EditSpelerViewModel(await _context.Teams.ToListAsync(), speler.ID, speler.Voornaam, speler.Achternaam, speler.Rugnummer, speler.Doelpunten, speler.TeamID));
        }

        private bool MatchExists(int id)
        {
            Match match = _context.Matches.Find(id);
            return match != null;
        }
    }
}
