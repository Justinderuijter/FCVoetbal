using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class EditGebruikerViewModel : CreateGebruikerViewModel
    {
        public EditGebruikerViewModel() : base() { }
        public EditGebruikerViewModel(IQueryable<IdentityRole> roleOptions, string id, string voornaam = "", string achternaam = "", string email = "", string telefoon = "", string wachtwoord = "") : base(roleOptions, voornaam, achternaam, email, telefoon, wachtwoord)
        {
            ID = id;
        }

        public string ID { get; set; }
    }
}
