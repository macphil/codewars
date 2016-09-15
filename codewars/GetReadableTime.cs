using NUnit.Framework;

namespace codewars
{
    public class GetReadableTime
    {
        [Test]
        [TestCase(0, ExpectedResult = "00:00:00")]
        [TestCase(5, ExpectedResult = "00:00:05")]
        [TestCase(60, ExpectedResult = "00:01:00")]
        [TestCase(86399, ExpectedResult = "23:59:59")]
        [TestCase(35999, ExpectedResult = "99:59:59")]
        public string GetReadableTime_Tests(int actual)
        {
            return $"{actual}";
        }
    }
}