using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserFilm
    {
        public MediaWebUser User { get; set; }
        [Key]
        public string UserId { get; set; }
        public Film Film { get; set; }
        [Key]
        public int FilmId { get; set; }
    }
}
