using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Media.Film
{
    public class FilmCreateViewModel : MediaCreateViewModel
    {
        public string Producer { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}
