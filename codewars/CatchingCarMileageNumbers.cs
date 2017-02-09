using System.Collections.Generic;
using NUnit.Framework;

namespace codewars
{
    public class CatchingCarMileageNumbers
    {
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            return -1;
        }

        [Test]
        [TestCase("", ExpectedResult = "")]
        public string CatchingCarMileageNumbers_Tests(string actual)
        {
            return actual;
        }

        [Test]
        public void ShouldWorkTest()
        {
            Assert.AreEqual(0, IsInteresting(3, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, IsInteresting(1336, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, IsInteresting(1337, new List<int>() { 1337, 256 }));
            Assert.AreEqual(0, IsInteresting(11208, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, IsInteresting(11209, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, IsInteresting(11211, new List<int>() { 1337, 256 }));
        }
    }
}