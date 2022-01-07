using FCVoetbal.Data;
using FCVoetbal.Models;
using FCVoetbal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FCVoetbal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MatchController : Controller
    {
        private readonly VoetbalContext _context;
        private readonly UserManager<Gebruiker> _userManager;
        public MatchController(VoetbalContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [AllowAnonymous]
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
                Match match = new Match()
                {
                    Plaats = vm.Plaats,
                    Datum = vm.Datum,
                    ThuisTeamId = vm.ThuisTeamId,
                    UitTeamId = vm.UitTeamId,
                    ThuisDoelpunten = vm.ThuisDoelpunten,
                    UitDoelpunten = vm.UitDoelpunten
                };
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Match match = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
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

            MatchViewModel matchViewModel = new MatchViewModel(match.Datum, match.Plaats, match.ThuisTeam, match.UitTeam, match.ThuisDoelpunten, match.UitDoelpunten);
            if (await FindGebruikerMatch(match.ID, _userManager.GetUserId(User)) != null)
            {
                matchViewModel.Volgend = true;
            }

            return View(matchViewModel);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Follow(int id)
        {
            if (!MatchExists(id))
            {
                return NotFound();
            }

            string userId = _userManager.GetUserId(User);
            GebruikerMatch gebruikerMatch = await FindGebruikerMatch(id, userId);
            if (gebruikerMatch == null && User.Identity.IsAuthenticated)
            {
                gebruikerMatch = new GebruikerMatch()
                {
                    MatchID = id,
                    GebruikerID = userId
                };
                _context.GebruikersMatches.Add(gebruikerMatch);
            }
            else
            {
                _context.GebruikersMatches.Remove(gebruikerMatch);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return View(new EditMatchViewModel(await _context.Teams.ToListAsync(), match.ID, match.Datum, match.Plaats, match.ThuisTeam, match.UitTeam, match.ThuisDoelpunten, match.UitDoelpunten));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
                [Bind("ThuisTeamId,UitTeamId,ThuisDoelpunten,UitDoelpunten,Plaats,Datum")] Match match)
        {
            match.ID = id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.ID))
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

            return View(new EditMatchViewModel(await _context.Teams.ToListAsync(), match.ID, match.Datum, match.Plaats, match.ThuisTeam, match.UitTeam, match.ThuisDoelpunten, match.UitDoelpunten));
        }

        private bool MatchExists(int id)
        {
            Match match = _context.Matches.Find(id);
            return match != null;
        }

        private async Task<GebruikerMatch> FindGebruikerMatch(int matchId, string userId)
        {
            return await _context.GebruikersMatches.Where(x => x.MatchID == matchId && x.GebruikerID == userId).FirstOrDefaultAsync();
        }
    }
}
