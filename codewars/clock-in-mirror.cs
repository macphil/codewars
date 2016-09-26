using System;
using NUnit.Framework;

namespace codewars
{
    public class clock_in_mirror
    {
        [Test]
        [TestCase("02:00", ExpectedResult = "10:00")]
        [TestCase("06:35", ExpectedResult = "05:25")]
        [TestCase("11:59", ExpectedResult = "12:01")]
        [TestCase("12:00", ExpectedResult = "12:00")]
        [TestCase("12:02", ExpectedResult = "11:58")]
        public string clock_in_mirror_Tests(string actualtimeInMirror)
        {
            return WhatIsTheTime(actualtimeInMirror);
        }

        private string WhatIsTheTime(string timeInMirror)
        {
            DateTime mirrorTime;

            DateTime.TryParse(timeInMirror, out mirrorTime);

            var twelve = DateTime.Parse("12:00");

            return $"{twelve.AddMinutes((twelve - mirrorTime).TotalMinutes):hh:mm}";
        }
    }
}