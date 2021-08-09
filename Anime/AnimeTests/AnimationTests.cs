using AnimeData;
using NUnit.Framework;
using AnimeBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeTests
{
    class AnimationTests
    {
        [SetUp]
        public void Setup()
        {
            // remove test entry in DB if present
            using (var db = new WatchListContext())
            {
                var selectedAnime =
                from c in db.Animes
                where c.AnimeName == "Noragami: Stray God"
                select c;

                db.Animes.RemoveRange(selectedAnime);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewAnimeIsAddedToDatabase_TheNumberOfAnimeIncreasesBy1()
        {
            using (var db = new WatchListContext())
            {
                var numberOfAnimesBefore = db.Animes.Count();

                var newAnime = new AnimeManager();
                newAnime.Create("Noragami: Stray God", "Action", "Series", 12, 2014, "Complete", "Dubbed", null, 16, "In times of need, if you look in the right place, you just may see a strange telephone number scrawled in red. If you call this number, you will hear a young man introduce himself as the Yato God. Yato is a minor deity and a self-proclaimed \"Delivery God, \" who dreams of having millions of worshippers. Without a single shrine dedicated to his name, however, his goals are far from being realized. He spends his days doing odd jobs for five yen apiece, until his weapon partner becomes fed up with her useless master and deserts him. Just as things seem to be looking grim for the god, his fortune changes when a middle school girl, Hiyori Iki, supposedly saves Yato from a car accident, taking the hit for him. Remarkably, she survives, but the event has caused her soul to become loose and hence able to leave her body. Hiyori demands that Yato return her to normal, but upon learning that he needs a new partner to do so, reluctantly agrees to help him find one. And with Hiyori's help, Yato's luck may finally be turning around.");

                var numberOfAnimesAfter = db.Animes.Count();

                Assert.That(numberOfAnimesBefore + 1, Is.EqualTo(numberOfAnimesAfter));
            }
        }

        [Test]
        public void WhenANewAnimeIsAdded_TheirDetailsAreCorrect()
        {
            using (var db = new WatchListContext())
            {
                var newAnime = new AnimeManager();
                newAnime.Create("Noragami: Stray God", "Action", "Series", 12, 2014, "Complete", "Dubbed", null, 16, "In times of need, if you look in the right place, you just may see a strange telephone number scrawled in red. If you call this number, you will hear a young man introduce himself as the Yato God. Yato is a minor deity and a self-proclaimed \"Delivery God, \" who dreams of having millions of worshippers. Without a single shrine dedicated to his name, however, his goals are far from being realized. He spends his days doing odd jobs for five yen apiece, until his weapon partner becomes fed up with her useless master and deserts him. Just as things seem to be looking grim for the god, his fortune changes when a middle school girl, Hiyori Iki, supposedly saves Yato from a car accident, taking the hit for him. Remarkably, she survives, but the event has caused her soul to become loose and hence able to leave her body. Hiyori demands that Yato return her to normal, but upon learning that he needs a new partner to do so, reluctantly agrees to help him find one. And with Hiyori's help, Yato's luck may finally be turning around.");
                var newAnimeInDatabase = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault();

                Assert.That(newAnimeInDatabase.Genre, Is.EqualTo("Action"));
                Assert.That(newAnimeInDatabase.Type, Is.EqualTo("Series"));
                Assert.That(newAnimeInDatabase.Episode, Is.EqualTo(12));
                Assert.That(newAnimeInDatabase.ReleaseYear, Is.EqualTo(2014));
                Assert.That(newAnimeInDatabase.Status, Is.EqualTo("Complete"));
                Assert.That(newAnimeInDatabase.Language, Is.EqualTo("Dubbed"));
                Assert.That(newAnimeInDatabase.Restriction, Is.Null);
                Assert.That(newAnimeInDatabase.Rank, Is.EqualTo(16));
                Assert.That(newAnimeInDatabase.Summary, Is.EqualTo("In times of need, if you look in the right place, you just may see a strange telephone number scrawled in red. If you call this number, you will hear a young man introduce himself as the Yato God. Yato is a minor deity and a self-proclaimed \"Delivery God, \" who dreams of having millions of worshippers. Without a single shrine dedicated to his name, however, his goals are far from being realized. He spends his days doing odd jobs for five yen apiece, until his weapon partner becomes fed up with her useless master and deserts him. Just as things seem to be looking grim for the god, his fortune changes when a middle school girl, Hiyori Iki, supposedly saves Yato from a car accident, taking the hit for him. Remarkably, she survives, but the event has caused her soul to become loose and hence able to leave her body. Hiyori demands that Yato return her to normal, but upon learning that he needs a new partner to do so, reluctantly agrees to help him find one. And with Hiyori's help, Yato's luck may finally be turning around."));
            }
        }

        [Test]
        public void WhenAnimeIDIsGiven_RetrieveAnimeName_ReturnsAnimeName()
        {
            using (var db = new WatchListContext())
            {
                var newAnime = new AnimeManager();
                newAnime.Create("Noragami: Stray God", "Action", "Series", 12, 2014, "Complete", "Dubbed", null, 16, "In times of need, if you look in the right place, you just may see a strange telephone number scrawled in red. If you call this number, you will hear a young man introduce himself as the Yato God. Yato is a minor deity and a self-proclaimed \"Delivery God, \" who dreams of having millions of worshippers. Without a single shrine dedicated to his name, however, his goals are far from being realized. He spends his days doing odd jobs for five yen apiece, until his weapon partner becomes fed up with her useless master and deserts him. Just as things seem to be looking grim for the god, his fortune changes when a middle school girl, Hiyori Iki, supposedly saves Yato from a car accident, taking the hit for him. Remarkably, she survives, but the event has caused her soul to become loose and hence able to leave her body. Hiyori demands that Yato return her to normal, but upon learning that he needs a new partner to do so, reluctantly agrees to help him find one. And with Hiyori's help, Yato's luck may finally be turning around.");
                var newAnimeId = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault();


                var testAnime = new AnimeManager();
                var result = testAnime.RetrieveAnimeName(newAnimeId.AnimeId);

                Assert.That(result, Is.EqualTo("Noragami: Stray God"));
            }
        }

        [Test]
        public void WhenAnimeIsUpdated_SelectedAnimeIsUpdated()
        {
            using (var db = new WatchListContext())
            {
                var newAnime = new AnimeManager();
                newAnime.Create("Noragami: Stray God");
                newAnime.Update("Noragami: Stray God", "Testing", "This", 1, 2000, "Database", "For", 2, 3, "Update");
                var newAnimeInDatabase = db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").FirstOrDefault();

                Assert.That(newAnimeInDatabase.Genre, Is.EqualTo("Testing"));
                Assert.That(newAnimeInDatabase.Type, Is.EqualTo("This"));
                Assert.That(newAnimeInDatabase.Episode, Is.EqualTo(1));
                Assert.That(newAnimeInDatabase.ReleaseYear, Is.EqualTo(2000));
                Assert.That(newAnimeInDatabase.Status, Is.EqualTo("Database"));
                Assert.That(newAnimeInDatabase.Language, Is.EqualTo("For"));
                Assert.That(newAnimeInDatabase.Restriction, Is.EqualTo(2));
                Assert.That(newAnimeInDatabase.Rank, Is.EqualTo(3));
                Assert.That(newAnimeInDatabase.Summary, Is.EqualTo("Update"));
            }
        }

        [Test]
        public void WhenAnimeIsNotInTheDatabase_Update_ReturnsFalse()
        {
            using (var db = new WatchListContext())
            {
                var animeManager = new AnimeManager();
                var result = animeManager.Update("Noragami");
                Assert.That(result, Is.False);
            }
        }

        [Test]
        public void WhenAnimeIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            using (var db = new WatchListContext())
            {
                var newAnime = new AnimeManager();
                newAnime.Create("Noragami: Stray God");

                var numberOfAnimeBefore = db.Animes.ToList().Count();

                var animeManager = new AnimeManager();
                animeManager.Delete("Noragami: Stray God");

                var numberOfAnimeAfter = db.Animes.ToList().Count();

                Assert.That(numberOfAnimeBefore, Is.EqualTo(numberOfAnimeAfter + 1));
            }
        }

        [Test]
        public void WhenAnimeIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new WatchListContext())
            {
                var newAnime = new AnimeManager();
                newAnime.Create("Noragami: Stray God");

                var animeManager = new AnimeManager();
                animeManager.Delete("Noragami: Stray God");

                int animeCheck = (int)(db.Animes.Where(c => c.AnimeName == "Noragami: Stray God").Count());

                Assert.That(animeCheck, Is.EqualTo(0));
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            using (var db = new WatchListContext())
            {
                var selectedAnime =
                from c in db.Animes
                where c.AnimeName == "Noragami: Stray God"
                select c;

                db.Animes.RemoveRange(selectedAnime);
                db.SaveChanges();

                var newAnime = new AnimeManager();
                newAnime.Create("Noragami: Stray God", "Action", "Series", 12, 2014, "Complete", "Dubbed", null, 16, "In times of need, if you look in the right place, you just may see a strange telephone number scrawled in red. If you call this number, you will hear a young man introduce himself as the Yato God. Yato is a minor deity and a self-proclaimed \"Delivery God, \" who dreams of having millions of worshippers. Without a single shrine dedicated to his name, however, his goals are far from being realized. He spends his days doing odd jobs for five yen apiece, until his weapon partner becomes fed up with her useless master and deserts him. Just as things seem to be looking grim for the god, his fortune changes when a middle school girl, Hiyori Iki, supposedly saves Yato from a car accident, taking the hit for him. Remarkably, she survives, but the event has caused her soul to become loose and hence able to leave her body. Hiyori demands that Yato return her to normal, but upon learning that he needs a new partner to do so, reluctantly agrees to help him find one. And with Hiyori's help, Yato's luck may finally be turning around.");
            }
        }
    }
}
