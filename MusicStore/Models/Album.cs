using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }

        // GRADY - This should be int ArtistId, not string Artist
        public string Artist { get; set; }
        public int Year { get; set; }

        // GRADY - Delete this property
        public object ArtistId { get; internal set; }
    }
}