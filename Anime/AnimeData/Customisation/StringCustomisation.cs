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
            string name = $"{FirstName} {LastName}\t\t\t- {Username}";

            int nameCount = FirstName.Count() + LastName.Count();
            if(nameCount > 12)
            {
                name = $"{FirstName} {LastName}\t\t- {Username}";
            }
            else if(nameCount > 18)
            {
                name = $"{FirstName} {LastName} - {Username}";
            }

            return name;
        }
    }
}
