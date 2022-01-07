using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class GebruikerViewModel
    {
        public GebruikerViewModel() { }
        public GebruikerViewModel(string voornaam = "", string achternaam = "", string email = "", string telefoon = "", string wachtwoord = "")
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            Telefoon = telefoon;
            Wachtwoord = wachtwoord;
        }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [Phone]
        public string Telefoon { get; set; }
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }
    }
}
