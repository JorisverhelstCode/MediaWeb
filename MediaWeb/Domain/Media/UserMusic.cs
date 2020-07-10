using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserMusic
    {
        public MediaWebUser User { get; set; }
        public string UserId { get; set; }
        public Music Music { get; set; }
        public int MusicId { get; set; }
    }
}
