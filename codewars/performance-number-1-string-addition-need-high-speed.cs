using System;
using System.Linq;
using NUnit.Framework;

namespace codewars
{
    [TestFixture]
    public class ComparingTests
    {
        private Random rand = new Random((int)DateTime.Now.Ticks);

        private int lastValue = -1;

        private int getRandomValue()
        {
            var i = rand.Next(0, 9);
            lastValue = i;
            return i;
        }

        [Test]
        public void PerformanceTest()
        {
            string actual = "";

            actual = Performance(getRandomValue);

            Assert.AreEqual(150000, actual.Length);
            Assert.AreEqual((char)(lastValue + 48), actual.Last());
        }

        public static string Performance(Func<int> getRandomValue)
        {
            throw new NotImplementedException();
        }
    }
}