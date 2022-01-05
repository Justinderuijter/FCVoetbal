using System;
using System.Collections.Generic;
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
            Datum = datum;
            TeamID = teamID;
        }

        public string Plaats { get; set; }
        public DateTime Datum { get; set; }
        public int TeamID { get; set; }
    }
}
