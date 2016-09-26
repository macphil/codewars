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
            var mirrorMinute = 60 - Convert.ToInt32(timeInMirror.Split(':')[1]);
            var mirrorHour = 12 - Convert.ToInt32(timeInMirror.Split(':')[0]);
            if (mirrorMinute == 60)
            {
                mirrorMinute = 0;
            }
            if (mirrorHour == 13)
            {
                mirrorHour--;
            }
            if (mirrorHour == 0)
            {
                mirrorHour = 12;
            }

            return $"{mirrorHour:D2}:{mirrorMinute:D2}";
        }
    }
}