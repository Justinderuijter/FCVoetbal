using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class EditTeamViewModel : TeamViewModel
    {
        public EditTeamViewModel(int id, string naam) : base(naam)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
