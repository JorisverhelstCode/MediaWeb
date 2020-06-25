using MediaWeb.Domain.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class PodCast : MediaListItem
    {
        public string Host { get; set; }
        public string Guest { get; set; }
    }
}
