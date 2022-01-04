using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Models
{
    public class Match
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ThuisTeamId { get; set; }
        [Required]
        public int UitTeamId { get; set; }
        public int? ThuisDoelpunten { get; set; }
        public int? UitDoelpunten { get; set; }
        [Required]
        public string Plaats { get; set; }
        [Required]
        public DateTime Datum { get; set; }

        //nav prop
        public Team ThuisTeam { get; set; }
        public Team UitTeam { get; set; }
        public ICollection<GebruikerMatch> GebruikerMatches { get; set; }
    }
}
