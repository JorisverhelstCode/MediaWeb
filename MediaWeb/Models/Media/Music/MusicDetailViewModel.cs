using MediaWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Music
{
    public class MusicDetailViewModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Artist { get; set; }
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
    }
}
