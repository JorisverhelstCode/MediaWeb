using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Media.Music
{
    public class MusicIndexViewModel
    {
        public List<MusicIndexListViewModel> Music { get; set; }

        public MusicIndexViewModel()
        {
            Music = new List<MusicIndexListViewModel>();
        }
    }
}
