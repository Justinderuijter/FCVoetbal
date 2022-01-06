using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Models
{
    public class GebruikerMatch
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string GebruikerID { get; set; }
        [Required]
        public int MatchID { get; set; }

        //nav prop
        public Gebruiker Gebruiker { get; set; }
        public Match Match { get; set; }
    }
}
