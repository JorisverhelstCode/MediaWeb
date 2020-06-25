using MediaWeb.Domain.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class Music : MediaListItem
    {
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
