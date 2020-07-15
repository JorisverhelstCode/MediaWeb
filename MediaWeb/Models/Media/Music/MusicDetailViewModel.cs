using MediaWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Music
{
    public class MusicDetailViewModel : Media.MediaDetailViewModel
    {
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
    }
}
