﻿using MediaWeb.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class Serie : Media.Media
    {
        public int Episode { get; set; }
        public string Producer { get; set; }
    }
}
