using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserSerie
    {
        public MediaWebUser User { get; set; }
        [Key]
        public string UserId { get; set; }
        public Serie Serie { get; set; }
        [Key]
        public int SerieId { get; set; }
    }
}
