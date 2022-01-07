using FCVoetbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class MatchListViewModel : ListViewModel<Match>
    {
        public MatchListViewModel() : base() { }
        public MatchListViewModel(List<Match> matches, bool onlyShowFollowed = false) : base(matches)
        {
            OnlyMine = onlyShowFollowed;
        }

        public bool OnlyMine { get; set; }
    }
}
