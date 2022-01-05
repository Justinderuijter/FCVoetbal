using FCVoetbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class EditTrainingViewModel : CreateTrainingViewModel
    {
        public EditTrainingViewModel(ICollection<Team> teamOptions, int id, string plaats, DateTime datum, int teamId = 0) : base(teamOptions, datum, plaats, teamId)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
