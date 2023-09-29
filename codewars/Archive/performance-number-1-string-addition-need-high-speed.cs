using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            Assert.That(actual.Length, Is.EqualTo(150000));
            Assert.That(actual.Last(), Is.EqualTo((char)(lastValue + 48)));
        }

        public static string Performance(Func<int> method)
        {
            var str = string.Empty;
            var builder = new System.Text.StringBuilder();
            builder.Append(str);
            for (int i = 0; i < 150000; i++)
            {
                builder.Append(method.Invoke());
            }

            return builder.ToString();
        }
    }
}