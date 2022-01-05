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
    public class SpelerController : Controller
    {
        private readonly VoetbalContext _context;
        public SpelerController(VoetbalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(new ListViewModel<Speler>(await _context.Spelers.Include(s => s.Team).ToListAsync()));
        }

        public async Task<IActionResult> Create()
        {
            return View(new CreateSpelerViewModel(await _context.Teams.ToListAsync()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Voornaam,Achternaam,Rugnummer,Doelpunten,TeamID")] Speler speler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(new CreateSpelerViewModel(await _context.Teams.ToListAsync(), speler.Voornaam, speler.Achternaam, speler.Rugnummer, speler.Doelpunten, speler.TeamID));
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Speler speler = await _context.Spelers.FirstOrDefaultAsync(m => m.ID == id);
            //var kl = await _context.Klanten.FindAsync(id);
            if (speler == null)
            {
                return NotFound();
            }


            return View(new SpelerViewModel(speler.Voornaam, speler.Achternaam, speler.Rugnummer, speler.Doelpunten, speler.TeamID));
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
                    if (!SpelerExists(speler.ID))
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

        private bool SpelerExists(int id)
        {
            Speler speler = _context.Spelers.Find(id);
            return speler != null;
        }
    }
}
