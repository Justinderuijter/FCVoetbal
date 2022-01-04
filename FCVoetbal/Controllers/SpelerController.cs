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
    public class SpelerController : Controller
    {
        private readonly VoetbalContext _context;
        public SpelerController(VoetbalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Speler> spelers = new List<Speler>();
            spelers.Add(new Speler(1, "Jef", "Jefson", 5, 3));
            spelers.Add(new Speler(2, "Bob", "Bobbers", 2));
            spelers.Add(new Speler(3, "Axel", "Maas"));
            spelers.Add(new Speler(4, "Jenny", "Huynh", 952, 9));
            spelers.Add(new Speler(5, "Jaap", "Jacobs", 1, 11));
            spelers.Add(new Speler(6, "Muy", "Bien", 420, 69));

            return View(new ListViewModel<Speler>(spelers));
        }
    }
}
