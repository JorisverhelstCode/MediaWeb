using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class PlayList
    {
        public IEnumerable<Music> List { get; set; }
    }
}
