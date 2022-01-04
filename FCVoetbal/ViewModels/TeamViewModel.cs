using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class TeamViewModel
    {
        public TeamViewModel() { }
        public TeamViewModel(string naam)
        {
            Naam = naam;
        }

        public string Naam { get; set; }
    }
}
