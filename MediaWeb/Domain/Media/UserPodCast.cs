using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserPodCast
    {
        public MediaWebUser User { get; set; }
        [Key]
        public string UserId { get; set; }
        public PodCast PodCast { get; set; }
        [Key]
        public int PodCastId { get; set; }
    }
}
