using System;
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
        [TestCase(359999, ExpectedResult = "99:59:59")]
        public string GetReadableTime_Tests(int seconds)
        { /*
            // the easy way using DateTime:
            var dateTime = new DateTime(0).AddSeconds(seconds);
            return $"{(Math.Floor((dateTime - new DateTime(0)).TotalHours)):00}:{dateTime:mm:ss}";
            */

            var secs = seconds % 60;
            var mins = seconds / 60 % 60;
            var hours = seconds / (60 * 60) % (60 * 60);

            return $"{hours:D2}:{mins:D2}:{secs:D2}";
        }
    }
}