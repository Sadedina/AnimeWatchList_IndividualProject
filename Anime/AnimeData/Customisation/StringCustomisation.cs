using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeData
{
    public partial class Profile
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName}\n- {Username}";
        }
    }

    public partial class Watchlist
    {
        public override string ToString()
        {
            return $"{AnimeId} - {Rating} - {Watching}";
        }
    }
}
