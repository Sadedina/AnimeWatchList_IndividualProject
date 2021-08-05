using AnimeData;
using AnimeBusiness;
using NUnit.Framework;
using System.Linq;

namespace AnimeTests
{
    public class ProfileTests
    {
        [SetUp]
        public void Setup()
        {
            // remove test entry in DB if present
            using (var db = new WatchListContext())
            {
                var selectedProfiles =
                from c in db.Profiles
                where c.Username == "manda89" || c.PersonId == "MANDA"
                select c;

                db.Profiles.RemoveRange(selectedProfiles);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewProfileIsCreated_TheNumberOfProfilesIncreasesBy1()
        {
            using (var db = new WatchListContext())
            {
                var numberOfProfilesBefore = db.Profiles.Count();

                var testProfile = new ProfileManager();
                testProfile.Create("manda89", "Nishant", "Mandal", 31, "UK");

                var numberOfProfilesAfter = db.Profiles.Count();

                Assert.That(numberOfProfilesBefore + 1, Is.EqualTo(numberOfProfilesAfter));
            }
        }

        [Test]
        public void WhenANewProfileIsAdded_TheirDetailsAreCorrect()
        {
            using (var db = new WatchListContext())
            {
                var testProfile = new ProfileManager();
                testProfile.Create("manda89", "Nishant", "Mandal", 31, "UK");
                var newProfile = db.Profiles.Where(c => c.Username == "manda89").FirstOrDefault();

                Assert.That(newProfile.FirstName, Is.EqualTo("Nishant"));
                Assert.That(newProfile.LastName, Is.EqualTo("Mandal"));
                Assert.That(newProfile.Age, Is.EqualTo(31));
                Assert.That(newProfile.Country, Is.EqualTo("UK"));
            }
        }

        [Test]
        public void WhenAProfileIsUpdated_SelectedCustomerIsUpdated()
        {
            using (var db = new WatchListContext())
            {
                db.Profiles.Add(new Profile { PersonId = "MANDA", Username = "manda89", FirstName = "Nishant", LastName = "Mandal", Age = 31, Country = "UK" });
                db.SaveChanges();


                var profileManager = new ProfileManager();
                profileManager.Update("manda89", "manda94", "Barack", "Obama", 32, "USA");

                Assert.That(profileManager.SelectedUser.Username, Is.EqualTo("manda94"));
                Assert.That(profileManager.SelectedUser.FirstName, Is.EqualTo("Barack"));
                Assert.That(profileManager.SelectedUser.LastName, Is.EqualTo("Obama"));
                Assert.That(profileManager.SelectedUser.Age, Is.EqualTo(32));
                Assert.That(profileManager.SelectedUser.Country, Is.EqualTo("USA"));
            }
        }

        [Test]
        public void WhenAProfileIsNotInTheDatabase_Update_ReturnsFalse()
        {
            using (var db = new WatchListContext())
            {
                var profileManager = new ProfileManager();
                var result = profileManager.Update("manda89", "manda94", "Barack", "Obama", 32, "USA");
                Assert.That(result, Is.False);
            }
        }

        [Test]
        public void WhenAProfileIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            using (var db = new WatchListContext())
            {
                db.Profiles.Add(new Profile { PersonId = "MANDA", Username = "manda89", FirstName = "Nishant", LastName = "Mandal", Age = 31, Country = "UK" });
                db.SaveChanges();

                var numberOfProfilesBefore = db.Profiles.ToList().Count();

                var profileManager = new ProfileManager();
                profileManager.Delete("manda89");

                var numberOfProfilesAfter = db.Profiles.ToList().Count();
                Assert.That(numberOfProfilesBefore, Is.EqualTo(numberOfProfilesAfter + 1));
            }
        }

        [Test]
        public void WhenAProfileIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new WatchListContext())
            {
                db.Profiles.Add(new Profile { PersonId = "MANDA", Username = "manda89", FirstName = "Nishant", LastName = "Mandal", Age = 31, Country = "UK" });
                db.SaveChanges();

                var profileManager = new ProfileManager();
                profileManager.Delete("manda89");

                int profileCheck = (int)(db.Profiles.Where(c => c.Username == "manda89").Count());

                Assert.That(profileCheck, Is.EqualTo(0));
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // remove test entry in DB if present
            using (var db = new WatchListContext())
            {
                var selectedProfiles =
                from c in db.Profiles
                where c.Username == "manda89" || c.PersonId == "MANDA"
                select c;

                db.Profiles.RemoveRange(selectedProfiles);
                db.SaveChanges();
            }
        }
    }
}