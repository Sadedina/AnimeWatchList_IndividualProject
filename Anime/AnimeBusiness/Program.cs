using System;
using AnimeData;

namespace AnimeBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            //db.AddRange(new Profile {PersonId = "MANDA", Username = "manda89", FirstName = "Nishant", LastName = "Manda", Age = 31, Country = "UK" });
            //db.SaveChanges();

            var newProfile = new ProfileManager();
            newProfile.Create("adedinsa", "Samuel", "Adedina", 28, "UK");
        }
    }
}
