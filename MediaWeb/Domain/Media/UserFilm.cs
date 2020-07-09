using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserFilm
    {
        public MediaWebUser User { get; set; }
        public string UserID { get; set; }
        public Film MyProperty { get; set; }
        public int FilmID { get; set; }
    }
}
