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

        public List<Watchlist> RetrieveAll()
        {
            using (var db = new WatchListContext())
            {
                return db.Watchlists.ToList();
            }
        }

        public void Create(string personId, int? animeId, int? rating, string watching)
        {
            var newWatchlist = new Watchlist()
            {
                PersonId = personId,
                AnimeId = animeId,
                Rating = rating,
                Watching = watching
            };

            using (var db = new WatchListContext())
            {
                var newWatchlistAdded = db.Watchlists.Where(c => c.PersonId == personId).FirstOrDefault();
                if (newWatchlistAdded == null)
                {
                    db.Watchlists.Add(newWatchlistAdded);
                    db.SaveChanges();
                }
                else
                {
                    Debug.WriteLine($"{personId} with this watchlist already exist!");
                }
            }
        }

        public bool Update(string personId, int? animeId, int? rating, string watching)
        {
            using (var db = new WatchListContext())
            {
                var newWatchlistUpdated = db.Watchlists.Where(c => c.PersonId == personId).FirstOrDefault();

                if (newWatchlistUpdated == null)
                {
                    Debug.WriteLine($"Username with {personId} not found");
                    return false;
                }
                newWatchlistUpdated.Rating = rating;
                newWatchlistUpdated.Watching = watching;

                // write changes to database
                try
                {
                    db.SaveChanges();
                    SelectedWatchlist = newWatchlistUpdated;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error updating {personId} watchlist");
                    return false;
                }
            }
            return true;
        }

        public bool Delete(string personId)
        {
            using (var db = new WatchListContext())
            {
                var newWatchlistDeleted = db.Watchlists.Where(c => c.PersonId == personId).FirstOrDefault();
                if (newWatchlistDeleted == null)
                {
                    Debug.WriteLine($"Watchlist with ID {personId} not found");
                    return false;
                }
                db.Watchlists.RemoveRange(newWatchlistDeleted);
                db.SaveChanges();
            }
            return true;
        }
    }
}
