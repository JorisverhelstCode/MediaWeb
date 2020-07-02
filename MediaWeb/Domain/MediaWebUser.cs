using MediaWeb.Domain.Media;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class MediaWebUser : IdentityUser
    {
        public List<PlayList> PlayLists { get; set; }
        public List<Music> MusicList { get; set; }
        public List<PodCast> PodCastList { get; set; }
        public List<Serie> SerieList { get; set; }
        public List<Film> FilmList { get; set; }
    }
}
