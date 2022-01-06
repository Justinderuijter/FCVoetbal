using FCVoetbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class CreateMatchViewModel : MatchViewModel
    {
        public CreateMatchViewModel() : base() { }
        public CreateMatchViewModel(ICollection<Team> teamOptions, DateTime datum, string plaats = "", Team thuisteam = null, Team uitteam = null, int? thuisDoelpunten = null, int? uitDoelpunten = null) : base(datum, plaats, thuisteam, uitteam, thuisDoelpunten, uitDoelpunten)
        {
            TeamsList = teamOptions.OrderBy(t => t.Naam).ToList();
        }

        public List<Team> TeamsList { get; set; }
    }
}
