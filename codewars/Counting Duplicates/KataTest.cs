namespace codewars.Counting_Duplicates
{
    using NUnit.Framework;

    [TestFixture]
    public class KataTest
    {
        [Test]
        [TestCase(0, "")]
        [TestCase(0, "abcde")]
        [TestCase(2, "aabbcde")]
        [TestCase(2, "aabBcde")]
        [TestCase(1, "Indivisibility")]
        [TestCase(2, "Indivisibilities")]
        public void KataTests(int expected, string given)
        {
            Assert.AreEqual(expected, Kata.DuplicateCount(given));
        }
    }
}