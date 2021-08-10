using AnimeBusiness;
using AnimeData;
using NUnit.Framework;
using System.Linq;

namespace AnimeTests
{
    class WatchlistTests
    {
        [SetUp]
        public void Setup()
        {
            // remove test entry in DB if present
            using (var db = new WatchListContext())
            {
                var animeExist = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault();
                int animesId = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault().AnimeId;
                if (animeExist == null)
                {
                    var newAnime = new AnimeManager();
                    newAnime.Create("Noragami: Stray God", "Action", "Series", 12, 2014, "Complete", "Dubbed", null, 16, "In times of need, if you look in the right place, you just may see a strange telephone number scrawled in red. If you call this number, you will hear a young man introduce himself as the Yato God. Yato is a minor deity and a self-proclaimed \"Delivery God, \" who dreams of having millions of worshippers. Without a single shrine dedicated to his name, however, his goals are far from being realized. He spends his days doing odd jobs for five yen apiece, until his weapon partner becomes fed up with her useless master and deserts him. Just as things seem to be looking grim for the god, his fortune changes when a middle school girl, Hiyori Iki, supposedly saves Yato from a car accident, taking the hit for him. Remarkably, she survives, but the event has caused her soul to become loose and hence able to leave her body. Hiyori demands that Yato return her to normal, but upon learning that he needs a new partner to do so, reluctantly agrees to help him find one. And with Hiyori's help, Yato's luck may finally be turning around.");
                }

                var profileExist = db.Profiles.Where(p => p.PersonId == "CANDY").FirstOrDefault();
                if(profileExist == null)
                {
                    db.AddRange(new Profile { PersonId = "CANDY", Username = "TayTay", FirstName = "Taylor", LastName = "Swift", Age = 31, Country = "USA" });
                    db.SaveChanges();
                }

                var profileWithAnime = db.Watchlists.Where(p => p.PersonId == "CANDY" && p.AnimeId == animesId).FirstOrDefault();
                if(profileWithAnime != null)
                {
                    db.Watchlists.RemoveRange(profileWithAnime);
                    db.SaveChanges();
                }
                
            }
        }

        [Test]
        public void WhenAPersonAddsAnimeToWatchlist_TheNumberOfWatchlistIncreasesBy1()
        {
            using (var db = new WatchListContext())
            {
                var numberOfWatchlistsBefore = db.Watchlists.Count();

                var newWatchlists = new WatchListManager();
                newWatchlists.Create("TayTay", "Noragami: Stray God");

                var numberOfWatchlistsAfter = db.Watchlists.Count();

                Assert.That(numberOfWatchlistsBefore + 1, Is.EqualTo(numberOfWatchlistsAfter));
            }
        }
        [Test]
        public void WhenAPersonAddsAnimeToWatchlistWithRating_TheNumberOfWatchlistIncreasesBy1()
        {
            using (var db = new WatchListContext())
            {
                var numberOfWatchlistsBefore = db.Watchlists.Count();

                var newWatchlists = new WatchListManager();
                newWatchlists.CreateRating("TayTay", "Noragami: Stray God", 1);

                var numberOfWatchlistsAfter = db.Watchlists.Count();

                Assert.That(numberOfWatchlistsBefore + 1, Is.EqualTo(numberOfWatchlistsAfter));
            }
        }
        [Test]
        public void WhenAPersonAddsAnimeToWatchlistWithWatching_TheNumberOfWatchlistIncreasesBy1()
        {
            using (var db = new WatchListContext())
            {
                var numberOfWatchlistsBefore = db.Watchlists.Count();

                var newWatchlists = new WatchListManager();
                newWatchlists.CreateWatching("TayTay", "Noragami: Stray God", "To Watch");

                var numberOfWatchlistsAfter = db.Watchlists.Count();

                Assert.That(numberOfWatchlistsBefore + 1, Is.EqualTo(numberOfWatchlistsAfter));
            }
        }


        [Test]
        public void WhenANewPersonAnimeIsAdded_TheirDetailsAreCorrect()
        {
            using (var db = new WatchListContext())
            {
                var newPersonAnime = new WatchListManager();
                newPersonAnime.Create("TayTay", "Noragami: Stray God", "To Watch", 2);

                int animesId = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault().AnimeId;
                var newPersonAndAnime = db.Watchlists.Where(c => c.PersonId == "CANDY" && c.AnimeId == animesId).FirstOrDefault();

                Assert.That(newPersonAndAnime.Rating, Is.EqualTo(2));
                Assert.That(newPersonAndAnime.Watching, Is.EqualTo("To Watch"));
            }
        }
        [Test]
        public void WhenANewPersonAnimeIsAddedWithRating_TheirDetailsAreCorrect()
        {
            using (var db = new WatchListContext())
            {
                var newPersonAnime = new WatchListManager();
                newPersonAnime.CreateRating("TayTay", "Noragami: Stray God", 5);

                int animesId = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault().AnimeId;
                var newPersonAndAnime = db.Watchlists.Where(c => c.PersonId == "CANDY" && c.AnimeId == animesId).FirstOrDefault();

                Assert.That(newPersonAndAnime.Rating, Is.EqualTo(5));
            }
        }
        [Test]
        public void WhenANewPersonAnimeIsAddedWithWatching_TheirDetailsAreCorrect()
        {
            using (var db = new WatchListContext())
            {
                var newPersonAnime = new WatchListManager();
                newPersonAnime.CreateWatching("TayTay", "Noragami: Stray God", "Watched");

                int animesId = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault().AnimeId;
                var newPersonAndAnime = db.Watchlists.Where(c => c.PersonId == "CANDY" && c.AnimeId == animesId).FirstOrDefault();

                Assert.That(newPersonAndAnime.Watching, Is.EqualTo("Watched"));
            }
        }


        [Test]
        public void WhenANewPersonAndAnimeIsIsUpdatedWithRating_SelectedAnimeIsUpdated()
        {
            using (var db = new WatchListContext())
            {
                var newWatchlists = new WatchListManager();
                newWatchlists.Create("TayTay", "Noragami: Stray God");
                newWatchlists.UpdateRating("TayTay", "Noragami: Stray God", 34);
                int animesId = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault().AnimeId;
                var newPersonAndAnime = db.Watchlists.Where(c => c.PersonId == "CANDY" && c.AnimeId == animesId).FirstOrDefault();

                Assert.That(newPersonAndAnime.Rating, Is.EqualTo(34));
            }
        }
        [Test]
        public void WhenANewPersonAndAnimeIsIsUpdatedWithWatching_SelectedAnimeIsUpdated()
        {
            using (var db = new WatchListContext())
            {
                var newWatchlists = new WatchListManager();
                newWatchlists.Create("TayTay", "Noragami: Stray God");
                newWatchlists.UpdateWatching("TayTay", "Noragami: Stray God", "Pizza");
                int animesId = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault().AnimeId;
                var newPersonAndAnime = db.Watchlists.Where(c => c.PersonId == "CANDY" && c.AnimeId == animesId).FirstOrDefault();

                Assert.That(newPersonAndAnime.Watching, Is.EqualTo("Pizza"));
            }
        }



        [Test]
        public void WhenPersonAndAnimeIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            using (var db = new WatchListContext())
            {
                var newWatchlists = new WatchListManager();
                newWatchlists.Create("TayTay", "Noragami: Stray God");

                var numberOfWatchlistsBefore = db.Watchlists.Count();

                newWatchlists.Delete("TayTay", "Noragami: Stray God");

                var numberOfWatchlistsAfter = db.Watchlists.Count();

                Assert.That(numberOfWatchlistsBefore - 1, Is.EqualTo(numberOfWatchlistsAfter));
            }
        }

        [Test]
        public void WhenPersonAndAnimeIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new WatchListContext())
            {
                var newWatchlists = new WatchListManager();
                newWatchlists.Create("TayTay", "Noragami: Stray God");

                newWatchlists.Delete("TayTay", "Noragami: Stray God");
                int animesId = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault().AnimeId;
                int personAndAnimeCheck = (int)(db.Watchlists.Where(c => c.PersonId == "CANDY" && c.AnimeId == animesId).Count());

                Assert.That(personAndAnimeCheck, Is.EqualTo(0));
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            using (var db = new WatchListContext())
            {
                var selectedPerson =
                from c in db.Watchlists
                where c.PersonId == "CANDY"
                select c;

                db.Watchlists.RemoveRange(selectedPerson);
                db.SaveChanges();
            }
        }
    }
}
