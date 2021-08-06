using System;
using System.Collections.Generic;

#nullable disable

namespace AnimeData
{
    public partial class Watchlist
    {
        public string PersonId { get; set; }
        public int? AnimeId { get; set; }
        public int? Rating { get; set; }
        public string Watching { get; set; }

        public virtual Anime Anime { get; set; }
        public virtual Profile Person { get; set; }
    }
}
