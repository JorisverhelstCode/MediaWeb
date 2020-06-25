using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class Film
    {
        public string Title { get; set; }

        [Key]
        public int Id { get; set; }
        public string Producer { get; set; }
        public string Url { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
