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
            return $"Name: {FirstName} {LastName}\n@{Username}";
        }
    }
    public partial class Anime
    {
        public override string ToString()
        {
            return $"{AnimeName}";
        }
    }
}
