using MediaWeb.Domain;
using MediaWeb.Views.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Music
{
    public class MusicEditViewModel : MediaEditViewModel
    {
        public string Artist { get; set; }
        public string Genre { get; set; }
    }
}
