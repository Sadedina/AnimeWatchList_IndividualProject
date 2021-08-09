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

        public UserWatchAnimeInc SelectedAnimeRetriveAll { get; set; }
        public void SetSelectedAnimeForInfo(object item)
        {
            SelectedAnimeRetriveAll = (UserWatchAnimeInc)item;
        }

        public List<UserWatchAnimeInc> RetrieveAllUsersInformationAndAnimes()
        {
            var list = new List<UserWatchAnimeInc>();

            using (var db = new WatchListContext())
            {
                var queryTotal =
                    from w in db.Watchlists
                    join a in db.Animes on w.AnimeId equals a.AnimeId
                    join p in db.Profiles on w.PersonId equals p.PersonId
                    select new
                    {
                        personId = p.PersonId,
                        username = p.Username,
                        animeId = a.AnimeId,
                        animeName = a.AnimeName,
                        rating = w.Rating,
                        watched = w.Watching,
                        genre = a.Genre,
                        episode = a.Episode,
                        releaseYear = a.ReleaseYear,
                        status = a.Status,
                        rank = a.Rank,
                        summary = a.Summary
                    };

                foreach (var item in queryTotal)
                {
                    var userWatched = new UserWatchAnimeInc();
                    userWatched.PersonId = item.personId;
                    userWatched.Username = item.username;
                    userWatched.AnimeId = item.animeId;
                    userWatched.AnimeName = item.animeName;
                    userWatched.Rating = item.rating;
                    userWatched.Watching = item.watched;
                    userWatched.Genre = item.genre;
                    userWatched.Episode = item.episode;
                    userWatched.ReleaseYear = item.releaseYear;
                    userWatched.Status = item.status;
                    userWatched.Rank = item.rank;
                    userWatched.Summary = item.summary;

                    list.Add(userWatched);
                }

                return list;
            }
        }
        public List<UserWatchAnimeInc> RetrieveAnimeDetailsGivenUsername(string name)
        {
            var list = new List<UserWatchAnimeInc>();
            using (var db = new WatchListContext())
            {
                var queryTotal =
                    from w in db.Watchlists
                    join a in db.Animes on w.AnimeId equals a.AnimeId
                    join p in db.Profiles on w.PersonId equals p.PersonId
                    where p.Username == name
                    select new
                    {
                        personId = p.PersonId,
                        username = p.Username,
                        animeId = a.AnimeId,
                        animeName = a.AnimeName,
                        rating = w.Rating,
                        watched = w.Watching,
                        genre = a.Genre,
                        episode = a.Episode,
                        releaseYear = a.ReleaseYear,
                        status = a.Status,
                        rank = a.Rank,
                        summary = a.Summary
                    };
                foreach (var item in queryTotal)
                {
                    var userWatched = new UserWatchAnimeInc();
                    userWatched.PersonId = item.personId;
                    userWatched.Username = item.username;
                    userWatched.AnimeId = item.animeId;
                    userWatched.AnimeName = item.animeName;
                    userWatched.Rating = item.rating;
                    userWatched.Watching = item.watched;
                    userWatched.Genre = item.genre;
                    userWatched.Episode = item.episode;
                    userWatched.ReleaseYear = item.releaseYear;
                    userWatched.Status = item.status;
                    userWatched.Rank = item.rank;
                    userWatched.Summary = item.summary;

                    list.Add(userWatched);
                }
                return list;
            }
        }
        public List<UserWatchAnimeInc> RetrieveAnimeDetailsGivenUser(string name)
        {
            var list = new List<UserWatchAnimeInc>();
            using (var db = new WatchListContext())
            {
                var queryTotal =
                    from w in db.Watchlists
                    join a in db.Animes on w.AnimeId equals a.AnimeId
                    join p in db.Profiles on w.PersonId equals p.PersonId
                    where name.Contains(a.AnimeName)
                    //where a.AnimeName == name
                    select new
                    {
                        personId = p.PersonId,
                        username = p.Username,
                        animeId = a.AnimeId,
                        animeName = a.AnimeName,
                        rating = w.Rating,
                        watched = w.Watching,
                        genre = a.Genre,
                        episode = a.Episode,
                        releaseYear = a.ReleaseYear,
                        status = a.Status,
                        rank = a.Rank,
                        summary = a.Summary
                    };
                foreach (var item in queryTotal)
                {
                    var userWatched = new UserWatchAnimeInc();
                    userWatched.PersonId = item.personId;
                    userWatched.Username = item.username;
                    userWatched.AnimeId = item.animeId;
                    userWatched.AnimeName = item.animeName;
                    userWatched.Rating = item.rating;
                    userWatched.Watching = item.watched;
                    userWatched.Genre = item.genre;
                    userWatched.Episode = item.episode;
                    userWatched.ReleaseYear = item.releaseYear;
                    userWatched.Status = item.status;
                    userWatched.Rank = item.rank;
                    userWatched.Summary = item.summary;

                    list.Add(userWatched);
                }
                return list;
            }
        }
        public List<UserWatchAnimeInc> RetrieveAllAnimesForSpecialList(string name)
        {
            var list = new List<UserWatchAnimeInc>();
            using (var db = new WatchListContext())
            {
                var queryTotal =
                    from a in db.Animes
                    where a.AnimeName == name
                    select new
                    {
                        animeId = a.AnimeId,
                        animeName = a.AnimeName,
                        genre = a.Genre,
                        episode = a.Episode,
                        releaseYear = a.ReleaseYear,
                        status = a.Status,
                        rank = a.Rank,
                        summary = a.Summary
                    };

                foreach (var item in queryTotal)
                {
                    var userWatched = new UserWatchAnimeInc();
                    userWatched.AnimeId = item.animeId;
                    userWatched.AnimeName = item.animeName;
                    userWatched.Genre = item.genre;
                    userWatched.Episode = item.episode;
                    userWatched.ReleaseYear = item.releaseYear;
                    userWatched.Status = item.status;
                    userWatched.Rank = item.rank;
                    userWatched.Summary = item.summary;

                    list.Add(userWatched);
                }

                return list;
            }
        }
        public List<Anime> RetrieveOtherAnimes(string username)
        {
            var list = new List<UserWatchAnimeInc>();
            using (var db = new WatchListContext())
            {
                var queryWatchedAnime =
                    from w in db.Watchlists
                    join a in db.Animes on w.AnimeId equals a.AnimeId
                    join p in db.Profiles on w.PersonId equals p.PersonId
                    where p.Username == username
                    select a;
                var allAnime =
                    from a in db.Animes select a;

                var animeList = new List<Anime>();
                foreach (var a in allAnime)
                {
                    animeList.Add(a);
                }

                var animeWatched = new List<Anime>();
                foreach (var item in queryWatchedAnime)
                {
                    animeWatched.Add(item);
                }

                /*         Chris's Version
                var animeNotWatched = new List<Anime>();
                for (int i = 0; i < animeList.Count; i++)
                {
                    bool watched = false;
                    foreach (var item in animeWatched)
                    {
                        if (animeList[i].AnimeId == item.AnimeId)
                        {
                            watched = true;
                        }
                    }
                    if (watched == false)
                    {
                        animeNotWatched.Add(animeList[i]);
                    }
                }*/

                var animeNotWatched = animeList;
                for (int i = 0; i < animeList.Count; i++)
                {
                    foreach (var item in animeWatched)
                    {
                        if (animeList[i].AnimeId == item.AnimeId)
                        {
                            animeNotWatched.Remove(item);
                        }
                    }
                }

                return animeNotWatched;
            }
        }

        public void CreateOrUpdate(string username, string animeTitle, string watching = null, int? rating = null)
        {
            if (animeTitle != null)
            {
                if (watching == "reset") watching = null;
                if (rating == -1) rating = null;

                using (var db = new WatchListContext())
                {
                    var findingUserId = db.Profiles.Where(c => c.Username == username).FirstOrDefault().PersonId;
                    int? findingAnimeId = db.Animes.Where(a => a.AnimeName == animeTitle).FirstOrDefault().AnimeId;
                    var animeOfUser = db.Watchlists.Where(w => w.PersonId == findingUserId && w.AnimeId == findingAnimeId).FirstOrDefault();

                    if (animeOfUser == null)
                    {
                        Create(username, animeTitle, watching, rating);
                    }
                    else
                    {
                        Update(username, animeTitle, watching, rating);
                    }
                }
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
                int? findingAnimeId = db.Animes.Where(a => a.AnimeName == animeTitle).FirstOrDefault().AnimeId;

                if (findingUserId == null && findingAnimeId == null)
                {
                    Debug.WriteLine($"Username {username} has not put {animeTitle} in their watchlist");
                    return false;
                }
                var toUpdateWatchlist = db.Watchlists.Where(c => c.PersonId == findingUserId && c.AnimeId == findingAnimeId).FirstOrDefault();


                //toUpdateWatchlist.PersonId = findingUserId;
                //toUpdateWatchlist.AnimeId = (int)findingAnimeId;
                toUpdateWatchlist.Watching = watching;
                toUpdateWatchlist.Rating = rating;

                // write changes to database
                try
                {
                    db.SaveChanges();
                    SelectedWatchlist = toUpdateWatchlist;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error updating {username}");
                    return false;
                }
            }
            return true;
        }

        public bool Delete(string username, string animeTitle)
        {
            if (animeTitle != null)
            {
                using (var db = new WatchListContext())
                {
                    var findingUserId = db.Profiles.Where(c => c.Username == username).FirstOrDefault().PersonId;
                    var findingAnimeId = db.Animes.Where(a => a.AnimeName == animeTitle).FirstOrDefault().AnimeId;

                    var delWatchlist = db.Watchlists.Where(c => c.PersonId == findingUserId && c.AnimeId == findingAnimeId).FirstOrDefault();

                    db.Watchlists.RemoveRange(delWatchlist);
                    db.SaveChanges();
                }
                
            }
            return true;
        }
    }
}
