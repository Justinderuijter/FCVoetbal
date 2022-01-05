using FCVoetbal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class CreateSpelerViewModel : SpelerViewModel
    {
        public CreateSpelerViewModel(ICollection<Team> teamOptions, string voornaam = "", string achternaam = "", int? rugnummer = null, int doelpunten = 0, int? teamID = null) : base(voornaam, achternaam, rugnummer, doelpunten, teamID)
        {
            TeamsList = teamOptions.OrderBy(x => x.Naam).ToList();
        }

        public List<Team> TeamsList { get; set; }
    }
}
