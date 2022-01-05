using FCVoetbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class CreateTrainingViewModel : TrainingViewModel
    {
        public CreateTrainingViewModel(ICollection<Team> teamOptions, DateTime datum, string plaats = "", int teamId = 0) : base(plaats, datum, teamId)
        {
            TeamsList = teamOptions.OrderBy(x => x.Naam).ToList();
        }

        public List<Team> TeamsList { get; set; }
    }
}
