using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Film
{
    public class FilmDetailViewModel
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Url { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
