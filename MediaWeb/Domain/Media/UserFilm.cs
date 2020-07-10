using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserFilm
    {
        public MediaWebUser User { get; set; }
        public string UserId { get; set; }
        public Film Film { get; set; }
        public int FilmId { get; set; }
    }
}
