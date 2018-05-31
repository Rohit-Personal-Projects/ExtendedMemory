using ExtendedMemory.DataAccess;
using NUnit.Framework;
using System;
namespace ExtendedMemory.Test
{
    [TestFixture()]
    public class Test
    {
        [Test]
        public void TestCase()
        {
            var m = new MemoryDatabase();
            var c = m.Get().Result.Item.Count;
            Assert.IsTrue(c > 0);
        }
    }
}
