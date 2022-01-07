using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class CreateGebruikerViewModel : GebruikerViewModel
    {
        public CreateGebruikerViewModel() : base() { }
        public CreateGebruikerViewModel(IQueryable<IdentityRole> roleOptions, string voornaam = "", string achternaam = "", string email = "", string telefoon = "", string wachtwoord = "") : base(voornaam, achternaam, email, telefoon, wachtwoord)
        {
            RolesList = roleOptions.OrderBy(r => r.Name).ToList();
        }

        public List<IdentityRole> RolesList { get; set; }
    }
}
