using FCVoetbal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCVoetbal.ViewModels
{
    public class ListViewModel<T> where T : class
    {
        public ListViewModel() { }
        public ListViewModel(List<T> items)
        {
            Items = items;
        }
        public List<T> Items { get; set; }
    }
}
