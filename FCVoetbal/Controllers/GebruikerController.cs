using FCVoetbal.Models;
using FCVoetbal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GebruikerController : Controller
    {
        private readonly UserManager<Gebruiker> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public GebruikerController(UserManager<Gebruiker> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(new ListViewModel<Gebruiker>(_userManager.Users.ToList()));
        }

        public IActionResult Create()
        {
            return View(new CreateGebruikerViewModel(_roleManager.Roles));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGebruikerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Gebruiker gebruiker = new Gebruiker()
                {
                    UserName = vm.Email,
                    Email = vm.Email,
                    Voornaam = vm.Voornaam,
                    Achternaam = vm.Achternaam,
                    PhoneNumber = vm.Telefoon
                };
                IdentityResult result = await _userManager.CreateAsync(gebruiker, vm.Wachtwoord);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                
            }

            return View(vm);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            Gebruiker gebruiker = await _userManager.FindByIdAsync(id);
            if (gebruiker == null)
            {
                return NotFound();
            }


            return View(new GebruikerViewModel(gebruiker.Voornaam, gebruiker.Achternaam, gebruiker.Email));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Gebruiker gebruiker = await _userManager.FindByIdAsync(id);
            if (gebruiker != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(gebruiker);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Gebruiker bestaat niet!");
            }
            return View(nameof(Index), _userManager.Users.ToList());
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }


            Gebruiker gebruiker = await _userManager.FindByIdAsync(id);

            if (gebruiker == null)
            {
                return NotFound();
            }
            return View(new EditGebruikerViewModel(_roleManager.Roles, gebruiker.Id, gebruiker.Voornaam, gebruiker.Achternaam, gebruiker.Email, gebruiker.PhoneNumber));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGebruikerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Gebruiker gebruiker = await _userManager.FindByIdAsync(vm.ID);
                try
                {
                    gebruiker = EditGebruiker(gebruiker, vm);
                    await _userManager.UpdateAsync(gebruiker);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebruikerExists(vm.ID))
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

            return View(vm);
        }

        private bool GebruikerExists(string id)
        {
            return _userManager.FindByIdAsync(id) != null;
        }

        private Gebruiker EditGebruiker(Gebruiker gebruiker, EditGebruikerViewModel vm)
        {
            if (gebruiker.Voornaam != vm.Voornaam) gebruiker.Voornaam = vm.Voornaam;
            if (gebruiker.Achternaam != vm.Achternaam) gebruiker.Achternaam = vm.Achternaam;
            if (gebruiker.PhoneNumber != vm.Telefoon) gebruiker.PhoneNumber = vm.Telefoon;
            if (gebruiker.Email != vm.Email) gebruiker.Email = vm.Email;
            if (gebruiker.UserName != vm.Email) gebruiker.UserName = vm.Email;

            return gebruiker;
        }
    }
}
