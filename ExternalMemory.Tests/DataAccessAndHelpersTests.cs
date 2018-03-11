using System;
using System.Linq;
using ExtendedMemory.DataAccess;
using ExtendedMemory.Models;
using NUnit.Framework;

namespace ExternalMemory.Tests
{
    [TestFixture]
    public class DataAccessAndHelpersTests
    {
        [Test]
        public void SaveTest()
        {
            var people = "Person1 Person2".Split(' ').ToList();
            var tags = "Tag1 Tag2".Split(' ').ToList();

            var memory = new Memory
            {
                Text = "From NUnit",
                People = people,
                Tags = tags,
                Location = new Location
                {
                    City = "Test city",
                    State = "Test state",
                    Country = "Test country"
                },
                DateTime = DateTime.Now,
            };

            var saveResponse = ExtendedMemory.DataAccess.Save(memory);
            var saveResponse = DependencyService.Get<IMemoryDatabase>().Save(memory);
            Assert.True(saveResponse.IsSuccess);
        }

        [Test]
        public void Fail()
        {
            Assert.False(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }
    }
}
