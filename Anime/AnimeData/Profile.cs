using System;
using System.Collections.Generic;

#nullable disable

namespace AnimeData
{
    public partial class Profile
    {
        public string PersonId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Country { get; set; }
    }
}
