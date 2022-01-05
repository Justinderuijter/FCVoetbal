using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.Models
{
    public class Training
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Plaats { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        [Required]
        public int TeamID { get; set; }

        //nav prop
        public virtual Team Team { get; set; }
    }
}
