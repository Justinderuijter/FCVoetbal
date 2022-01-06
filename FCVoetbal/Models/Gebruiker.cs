using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Models
{
    public class Gebruiker : IdentityUser
    {
        [Required, PersonalData]
        public string Voornaam { get; set; }
        [Required, PersonalData]
        public string Achternaam { get; set; }
        [PersonalData]
        public string Telefoon { get; set; }
        //nav prop
        public ICollection<GebruikerMatch> GebruikersMatch { get; set; }
    }
}
