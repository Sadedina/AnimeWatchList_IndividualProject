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

        public List<string> RetrieveUsername()
        {
            using (var db = new WatchListContext())
            {
                return db.Profiles.Select(c => c.Username).ToList();
            }
        }

        public string RetrieveUserId(string username)
        {
            using (var db = new WatchListContext())
            {
                return db.Profiles.Where(c => c.Username == username).FirstOrDefault().PersonId;
            }
        }

        public void Create(string username, string firstName, string lastName, int age, string country)
        {
            // Making unique personal Id for User that is unchangable, even when username is changed
            string personalId = $"{username.ToLower().Substring(0, 3)}{firstName.ToUpper().Substring(0, 3)}{lastName.ToUpper().Substring(0, 2)}";
            
            var newProf = new Profile()
            {
                PersonId = personalId
                , Username = username
                , FirstName = firstName
                , LastName = lastName
                , Age = age
                , Country = country
            };

            using (var db = new WatchListContext())
            {
                var profileID = db.Profiles.Where(c => c.Username == username || c.PersonId == personalId).FirstOrDefault();
                if (profileID == null )
                {
                    db.Profiles.Add(newProf);
                    db.SaveChanges();
                }
                else
                {
                    Debug.WriteLine($"{username} already exist!");
                }
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
                    Debug.WriteLine($"Profile with {username} not found");
                    return false;
                }
                
                var idOfProfile = db.Profiles.Where(c => c.Username == username).FirstOrDefault().PersonId;
                var hasWatchlist = db.Watchlists.Where(c => c.PersonId == idOfProfile).FirstOrDefault();
                var number = db.Watchlists.Where(c => c.PersonId == idOfProfile).Count();

                if (hasWatchlist != null)
                {
                    while (hasWatchlist != null)
                    {
                        db.Watchlists.RemoveRange(hasWatchlist);
                        db.SaveChanges();
                        hasWatchlist = db.Watchlists.Where(c => c.PersonId == idOfProfile).FirstOrDefault();
                    }
                }
                
                db.Profiles.RemoveRange(profileID);
                db.SaveChanges();
            }
            return true;
        }
    }
}