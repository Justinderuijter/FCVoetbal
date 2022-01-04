using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Models
{
    public class Team
    {
        public Team(int id, string naam)
        {
            ID = id;
            Naam = naam;
        }
        [Key]
        public int ID { get; set; }
        [Required]
        public string Naam { get; set; }

        //nav prop
        public ICollection<Training> Trainingen { get; set; }
        public ICollection<Speler> Spelers { get; set; }
    }
}
