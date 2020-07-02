using MediaWeb.Domain.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class Film : MediaListItem
    {
        public string Producer { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
    }
}
