using FCVoetbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class EditMatchViewModel : CreateMatchViewModel
    {
        public EditMatchViewModel(ICollection<Team> teamOptions, int id, DateTime datum, string plaats = "", Team thuisteam = null, Team uitteam = null, int? thuisDoelpunten = null, int? uitDoelpunten = null) : base(teamOptions, datum, plaats, thuisteam, uitteam, thuisDoelpunten, uitDoelpunten)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
