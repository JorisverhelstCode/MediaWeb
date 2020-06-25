using MediaWeb.Domain.Media;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain
{
    public class MediaWebUser : IdentityUser
    {
        public PlayList PlayList { get; set; }
        public IEnumerable<MediaListItem> MediaList { get; set; }
    }
}
