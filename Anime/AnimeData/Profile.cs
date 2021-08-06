using System;
using System.Collections.Generic;

#nullable disable

namespace AnimeData
{
    public partial class Profile
    {
        public Profile()
        {
            Watchlists = new HashSet<Watchlist>();
        }

        public string PersonId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Watchlist> Watchlists { get; set; }
    }
}
