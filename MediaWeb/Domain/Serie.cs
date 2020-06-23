using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class Serie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Episode { get; set; }
        public string Url { get; set; }
        public string Producer { get; set; }

    }
}
