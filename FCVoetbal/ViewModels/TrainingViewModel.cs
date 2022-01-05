using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class TrainingViewModel
    {
        public TrainingViewModel() { }
        public TrainingViewModel(string plaats, DateTime datum, int teamID = 0)
        {
            Plaats = plaats;
            Datum = datum.Date;
            TeamID = teamID;
        }

        public string Plaats { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public int TeamID { get; set; }
    }
}
