using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class SpelerViewModel
    {
        public SpelerViewModel()
        {

        }
        public SpelerViewModel(string voornaam, string achternaam, int? rugnummer, int doelpunten, int teamID = 0)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Rugnummer = rugnummer;
            Doelpunten = doelpunten;
            TeamID = teamID;
        }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int? Rugnummer { get; set; }
        public int Doelpunten { get; set; }
        public int TeamID { get; set; }
    }
}
