using AnimeData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeBusiness
{
    public class WatchListManager
    {
        public Watchlist SelectedWatchlist { get; set; }

        public void SetSelectedWatchlist(object selectedWatchlist)
        {
            SelectedWatchlist = (Watchlist)selectedWatchlist;
        }

        public List<Watchlist> RetrieveAllUsersAnime(string userId)
        {
            using (var db = new WatchListContext())
            {
                return db.Watchlists.Where(p => p.PersonId == userId).ToList();
            }
        }

        public void Create(string username, string animeTitle, string watching = null, int? rating = null)
        {
            using (var db = new WatchListContext())
            {
                var findingUserId = db.Profiles.Where(c => c.Username == username).FirstOrDefault().PersonId;
                var findingAnimeId = db.Animes.Where(a => a.AnimeName == animeTitle).FirstOrDefault().AnimeId;
                var newWatchlistDetail = new Watchlist()
                {
                    PersonId = findingUserId,
                    AnimeId = findingAnimeId,
                    Rating = rating,
                    Watching = watching
                };
                db.Watchlists.Add(newWatchlistDetail);
                db.SaveChanges();
            }
        }

        public bool Update(string username, string animeTitle, string watching = null, int? rating = null)
        {
            using (var db = new WatchListContext())
            {
                var findingUserId = db.Profiles.Where(c => c.Username == username).FirstOrDefault().PersonId;
                var findingAnimeId = db.Animes.Where(a => a.AnimeName == animeTitle).FirstOrDefault().AnimeId;

                if (findingUserId == null)
                {
                    Debug.WriteLine($"Username with {username} not found");
                    return false;
                }

                var newWatchlistDetail = new Watchlist()
                {
                    PersonId = findingUserId,
                    AnimeId = findingAnimeId,
                    Watching = watching,
                    Rating = rating
                };

                // write changes to database
                try
                {
                    db.Watchlists.Add(newWatchlistDetail);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error updating {username} watchlists");
                    return false;
                }
                return true;
            }
        }

        public bool Delete(string username, string animeTitle)
        {
            using (var db = new WatchListContext())
            {
                var findingUserId = db.Profiles.Where(c => c.Username == username).FirstOrDefault().PersonId;
                var findingAnimeId = db.Animes.Where(a => a.AnimeName == animeTitle).FirstOrDefault().AnimeId;

                var delWatchlist = db.Watchlists.Where(c => c.PersonId == findingUserId && c.AnimeId == findingAnimeId).FirstOrDefault();

                db.Watchlists.RemoveRange(delWatchlist);
                db.SaveChanges();
            }
            return true;
        }
    }
}
