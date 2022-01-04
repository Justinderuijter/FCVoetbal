using FCVoetbal.Data;
using FCVoetbal.Models;
using FCVoetbal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Controllers
{
    public class TeamController : Controller
    {
        private readonly VoetbalContext _context;
        public TeamController(VoetbalContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team(1, "KSK Weelde"));
            teams.Add(new Team(2, "FC Turnhout"));
            teams.Add(new Team(3, "HIH"));

            return View(new ListViewModel<Team>(teams));
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
            CreateTeamViewModel vm = new CreateTeamViewModel()
            {
                Naam = team.Naam
            };

            return View(vm);
        }
    }
}
