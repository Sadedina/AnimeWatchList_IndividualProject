using System;
using AnimeData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AnimeBusiness
{
    public class ProfileManager
    {
        public Profile SelectedUser { get; set; }

        public void SetSelectedUser(object selectedUser)
        {
            SelectedUser = (Profile)selectedUser;
        }

        public List<Profile> RetrieveAll()
        {
            using (var db = new WatchListContext())
            {
                return db.Profiles.ToList();
            }
        }

        public void Create(string username, string firstName, string lastName, int age, string country)
        {
            var newProf = new Profile()
            {
                PersonId = $"{username.ToLower().Substring(0,3)}{firstName.ToUpper().Substring(0,3)}{lastName.ToUpper().Substring(0,3)}"
                ,Username = username
                ,FirstName = firstName
                ,LastName = lastName
                ,Age = age
                ,Country = country
            };

            using (var db = new WatchListContext())
            {
                db.Profiles.Add(newProf);
                db.SaveChanges();
            }
        }

        public bool Update(string oldUsername, string username, string firstName, string lastName, int age, string country)
        {
            using (var db = new WatchListContext())
            {
                var profileID = db.Profiles.Where(c => c.Username == oldUsername).FirstOrDefault();

                if (profileID == null)
                {
                    Debug.WriteLine($"Username {oldUsername} not found");
                    return false;
                }
                profileID.Username = username;
                profileID.FirstName = firstName;
                profileID.LastName = lastName;
                profileID.Age = age;
                profileID.Country = country;
                // write changes to database
                try
                {
                    db.SaveChanges();
                    SelectedUser = profileID;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error updating {username}");
                    return false;
                }
            }
            return true;
        }

        public bool Delete(string username)
        {
            using (var db = new WatchListContext())
            {
                var profileID = db.Profiles.Where(c => c.Username == username).FirstOrDefault();
                if (profileID == null)
                {
                    Debug.WriteLine($"Customer {username} not found");
                    return false;
                }
                db.Profiles.RemoveRange(profileID);
                db.SaveChanges();
            }
            return true;
        }
    }
}
