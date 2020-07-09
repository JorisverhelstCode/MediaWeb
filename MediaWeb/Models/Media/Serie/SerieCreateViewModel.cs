using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Media.Serie
{
    public class SerieCreateViewModel : MediaCreateViewModel
    {
        public int Episode { get; set; }
        public string Producer { get; set; }
    }
}
