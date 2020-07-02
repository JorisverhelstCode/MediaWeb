using MediaWeb.Models.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.PodCast
{
    public class PodCastCreateViewModel : MediaCreateViewModel
    {
        public string Host { get; set; }
        public string Guest { get; set; }
    }
}
