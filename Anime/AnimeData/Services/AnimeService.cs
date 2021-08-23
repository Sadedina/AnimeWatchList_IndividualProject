using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeData.Services
{
    public class AnimeService : IAnimeServices
    {
        private readonly WatchListContext _context;

        public AnimeService(WatchListContext context)
        {
            _context = context;
        }

        public AnimeService()
        {
            _context = new WatchListContext();
        }



        public Anime GetAnimeByName(string animeName)
        {
            return _context.Animes.Where(c => c.AnimeName == animeName).FirstOrDefault();
        }
        public Anime GetAnimeById(int animeId)
        {
            return _context.Animes.Where(c => c.AnimeId == animeId).FirstOrDefault();
        }
        public void CreateAnime(Anime a)
        {
            if (a.AnimeName == null)
            {
                _context.Animes.Add(a);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Anime with username already exist!");
            }
        }

        public List<Anime> GetAnimeList()
        {
            throw new NotImplementedException();
        }

        public void RemoveAnime(Anime c)
        {
            throw new NotImplementedException();
        }

        public void SaveAnimeChanges()
        {
            throw new NotImplementedException();
        }
    }
}
