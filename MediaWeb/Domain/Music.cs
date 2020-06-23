using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class Music
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Artist { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
