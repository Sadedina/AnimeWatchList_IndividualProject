using System;
using System.Collections.Generic;

#nullable disable

namespace AnimeData
{
    public partial class Anime
    {
        public Anime()
        {
            Watchlists = new HashSet<Watchlist>();
        }

        public int AnimeId { get; set; }
        public string AnimeName { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public int? Episode { get; set; }
        public int? ReleaseYear { get; set; }
        public string Status { get; set; }
        public string Language { get; set; }
        public int? Restriction { get; set; }
        public int? Rank { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<Watchlist> Watchlists { get; set; }
    }
}
