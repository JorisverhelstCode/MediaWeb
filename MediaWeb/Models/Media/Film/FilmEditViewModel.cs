using MediaWeb.Views.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Film
{
    public class FilmEditViewModel :  MediaEditViewModel
    {
        public string Producer { get; set; }
        public string Description { get; set; }
    }
}
