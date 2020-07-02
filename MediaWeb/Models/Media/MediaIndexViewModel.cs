using MediaWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Media
{
    public class MediaIndexViewModel
    {
        public List<MediaIndexListViewModel> MediaList { get; set; }
        public List<PlayList> PlayLists { get; set; }
    }
}
