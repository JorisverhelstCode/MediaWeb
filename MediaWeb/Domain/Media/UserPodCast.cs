﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public class UserPodCast
    {
        public MediaWebUser User { get; set; }
        public string UserID { get; set; }
        public PodCast PodCast { get; set; }
        public int PodCastID { get; set; }
    }
}
