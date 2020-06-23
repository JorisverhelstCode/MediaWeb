using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class PodCast
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Host { get; set; }
        public List<String> Guests { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
