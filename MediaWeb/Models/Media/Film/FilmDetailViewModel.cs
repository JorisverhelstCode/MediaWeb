using MediaWeb.Models.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Film
{
    public class FilmDetailViewModel : MediaDetailViewModel
    {
        public string Producer { get; set; }
        public string Description { get; set; }
    }
}
