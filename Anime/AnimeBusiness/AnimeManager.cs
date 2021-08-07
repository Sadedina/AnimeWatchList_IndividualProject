using System;
using AnimeData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AnimeBusiness
{
    public class AnimeManager
    {
        public Anime SelectedAnime { get; set; }

        public void SetSelectedAnime(object selectedAnime)
        {
            SelectedAnime = (Anime)selectedAnime;
        }

        public List<Anime> RetrieveAll()
        {
            using (var db = new WatchListContext())
            {
                return db.Animes.ToList();
            }
        }

        public string RetrieveAnimeName(int animeNameId)
        {
            using (var db = new WatchListContext())
            {
                return db.Animes.Where(c => c.AnimeId == animeNameId).FirstOrDefault().AnimeName;
            }
        }

        public void Create(string animeName, string genre = null, string type = null, int? episode = null, int? releaseYear = null, string status = null, string language = null, int? restriction = null, int? rank = null, string summary = null)
        {
            var newAnime = new Anime()
            {
                AnimeName = animeName
                ,Genre = genre
                ,Type = type
                ,Episode = episode
                ,ReleaseYear = releaseYear
                ,Status = status
                ,Language = language
                ,Restriction = restriction
                ,Rank = rank
                ,Summary = summary
            };

            using (var db = new WatchListContext())
            {
                var toAddAnime = db.Animes.Where(c => c.AnimeName == animeName).FirstOrDefault();
                if (toAddAnime == null)
                {
                    db.Animes.Add(newAnime);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Anime with username already exist!");
                }
            }
        }

        ///////////////////////////// USED FOR ADDING ANIMES INTO DATABASE
        ///// not needed for application
        
        public bool Update(string animeName, string genre = null, string type = null, int? episode = null, int? releaseYear = null, string status = null, string language = null, int? restriction = null, int? rank = null, string summary = null)
        {
            using (var db = new WatchListContext())
            {
                var toUpdateAnime = db.Animes.Where(c => c.AnimeName == animeName).FirstOrDefault();
                if (toUpdateAnime == null)
                {
                    Debug.WriteLine($"{animeName} is not found in database!");
                    return false;
                }

                toUpdateAnime.AnimeName = animeName;
                toUpdateAnime.Genre = genre;
                toUpdateAnime.Type = type;
                toUpdateAnime.Episode = episode;
                toUpdateAnime.ReleaseYear = releaseYear;
                toUpdateAnime.Status = status;
                toUpdateAnime.Language = language;
                toUpdateAnime.Restriction = restriction;
                toUpdateAnime.Rank = rank;
                toUpdateAnime.Summary = summary;

                // write changes to database
                try
                {
                    db.SaveChanges();
                    SelectedAnime = toUpdateAnime;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error updating {animeName}");
                    return false;
                }
            }
            return true;
        }
        public bool Delete(string animeName)
        {
            using (var db = new WatchListContext())
            {
                var toDeleteAnime = db.Animes.Where(c => c.AnimeName == animeName).FirstOrDefault();
                if (toDeleteAnime == null)
                {
                    Debug.WriteLine($"{animeName} is not found in database!");
                    return false;
                }
                db.Animes.RemoveRange(toDeleteAnime);
                db.SaveChanges();
            }
            return true;
        }
    }
}
