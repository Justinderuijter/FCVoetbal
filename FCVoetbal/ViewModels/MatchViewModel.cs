using FCVoetbal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class MatchViewModel
    {
        public MatchViewModel() { }
        public MatchViewModel(DateTime datum, string plaats = "", Team thuisteam = null, Team uitteam = null, int? thuisDoelpunten = null, int? uitDoelpunten = null)
        {
            Plaats = plaats;
            Datum = datum;
            ThuisTeam = thuisteam;
            UitTeam = uitteam;
            ThuisDoelpunten = thuisDoelpunten;
            UitDoelpunten = uitDoelpunten;
            if (ThuisTeam == null)
            {
                ThuisTeamId = 0;
            }
            else
            {
                ThuisTeamId = ThuisTeam.ID;
            }

            if (UitTeam == null)
            {
                UitTeamId = 0;
            }
            else
            {
                UitTeamId = UitTeam.ID;
            }
        }

        public string Plaats { get; set; }
        public DateTime Datum { get; set; }
        public int ThuisTeamId { get; set; }
        public int UitTeamId { get; set; }
        public Team ThuisTeam { get; set; }
        public Team UitTeam { get; set; }
        public int? ThuisDoelpunten { get; set; }
        public int? UitDoelpunten { get; set; }
        public bool Volgend { get; set; }
    }
}
