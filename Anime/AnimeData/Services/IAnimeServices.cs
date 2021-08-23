using System.Collections.Generic;

namespace AnimeData.Services
{
    public interface IAnimeServices
    {
        public List<Anime> GetAnimeList();
        public Anime GetAnimeById(string animeName);
        public void CreateAnime(Anime a);
        public void SaveAnimeChanges();
        public void RemoveAnime(Anime c);
    }
}