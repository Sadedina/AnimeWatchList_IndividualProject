using AnimeData;
using AnimeBusiness;
using NUnit.Framework;
using System.Linq;

namespace AnimeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // remove test entry in DB if present
            using (var db = new WatchListContext())
            {
                var selectedProfiles =
                from c in db.Profiles
                where c.Username == "manda89"
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
                var newProfile = db.Profiles.Find("manNISMAN");
                Assert.That(newProfile.FirstName, Is.EqualTo("Nishant"));
                Assert.That(newProfile.LastName, Is.EqualTo("Mandal"));
                Assert.That(newProfile.Age, Is.EqualTo(31));
                Assert.That(newProfile.Country, Is.EqualTo("UK"));
            }
        }
    }
}