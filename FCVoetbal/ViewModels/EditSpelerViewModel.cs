using FCVoetbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class EditSpelerViewModel : CreateSpelerViewModel
    {
        public EditSpelerViewModel(ICollection<Team> teamOptions, int id, string voornaam, string achternaam, int? rugnummer, int doelpunten, int teamID = 0) : base(teamOptions ,voornaam, achternaam, rugnummer, doelpunten, teamID)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
