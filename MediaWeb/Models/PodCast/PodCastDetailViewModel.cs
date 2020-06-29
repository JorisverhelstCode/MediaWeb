using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.PodCast
{
    public class PodCastDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Host { get; set; }
        public string Guest { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
