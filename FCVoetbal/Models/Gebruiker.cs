using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Models
{
    public class Gebruiker
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Wachtwoord { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telefoon { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        //nav prop
        public ICollection<GebruikerMatch> GebruikersMatch { get; set; }
    }
}
