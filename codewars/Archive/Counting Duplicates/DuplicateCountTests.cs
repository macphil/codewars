namespace codewars.Counting_Duplicates
{
    using NUnit.Framework;

    [TestFixture]
    public class DuplicateCountTests
    {
        [Test]
        [TestCase(0, "")]
        [TestCase(0, "abcde")]
        [TestCase(2, "aabbcde")]
        [TestCase(2, "aabBcde")]
        [TestCase(1, "Indivisibility")]
        [TestCase(2, "Indivisibilities")]
        public void DuplicateCountTest(int expected, string given)
        {
            Assert.AreEqual(expected, DuplicateCountKata.DuplicateCount(given));
        }
    }
}