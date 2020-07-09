using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Media.Film
{
    public class FilmIndexViewModel
    {
        public List<FilmIndexListViewModel> Films { get; set; }

        public FilmIndexViewModel()
        {
            Films = new List<FilmIndexListViewModel>();
        }
    }
}
