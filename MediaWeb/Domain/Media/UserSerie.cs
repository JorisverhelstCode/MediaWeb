using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserSerie
    {
        public MediaWebUser User { get; set; }
        public string UserId { get; set; }
        public Serie Serie { get; set; }
        public int SerieId { get; set; }
    }
}
