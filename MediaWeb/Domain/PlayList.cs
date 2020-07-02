﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class PlayList
    {
        public int Id { get; set; }
        public List<Music> MusicList { get; set; }
        public string Name { get; set; }
    }
}
