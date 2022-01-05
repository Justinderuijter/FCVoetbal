using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Models
{
    public class Speler
    {
        private int? _teamId;
        public Speler() { }
        public Speler(int id, string voornaam, string achternaam, int doelpunten = 0, int? rugnummer = null)
        {
            ID = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Doelpunten = doelpunten;
            Rugnummer = rugnummer;
        }
        public int ID { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [NotMapped]
        public string VolledigeNaam => $"{Voornaam} {Achternaam}";
        public int? Rugnummer { get; set; }
        [Required]
        public int Doelpunten { get; set; }
        public int? TeamID
        {
            get => _teamId;
            set
            {
                if (value == 0)
                {
                    _teamId = null;
                }
                else
                {
                    _teamId = value;
                }
            }
        }

        //nav prop
        public Team Team { get; set; }
    }
}
