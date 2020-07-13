using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserMusic
    {
        public MediaWebUser User { get; set; }
        [Key]
        public string UserId { get; set; }
        public Music Music { get; set; }
        [Key]
        public int MusicId { get; set; }
    }
}
