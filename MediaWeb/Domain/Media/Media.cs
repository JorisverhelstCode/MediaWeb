﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Media
{
    public abstract class Media
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
