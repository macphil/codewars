using System;
using codewars._7Segment;
using NUnit.Framework;

namespace codewars
{
    // https://www.codewars.com/kata/7-segment-converter/csharp
    public class SevenSegmentConverter
    {
        public static int SevenSegmentNumber(int number)
        {
            switch (number)
            {
                case 0:
                    return SevenSegment.Nr0.Value();

                case 1:
                    return SevenSegment.Nr1.Value();

                case 2:
                    return SevenSegment.Nr2.Value();

                case 3:
                    return SevenSegment.Nr3.Value();

                case 4:
                    return SevenSegment.Nr4.Value();

                case 5:
                    return SevenSegment.Nr5.Value();

                case 6:
                    return SevenSegment.Nr6.Value();

                case 7:
                    return SevenSegment.Nr7.Value();

                case 8:
                    return SevenSegment.Nr8.Value();

                case 9:
                    return SevenSegment.Nr9.Value();

                default:
                    return -1;
            }
        }

        [Test]
        public void AllNr()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}:");
                SevenSegmentNumber(i);
            }
        }

        [Test]
        [TestCase(0, ExpectedResult = 125)]
        [TestCase(1, ExpectedResult = 80)]
        [TestCase(2, ExpectedResult = 55)]
        [TestCase(3, ExpectedResult = 87)]
        [TestCase(4, ExpectedResult = 90)]
        [TestCase(5, ExpectedResult = 79)]
        [TestCase(6, ExpectedResult = 111)]
        [TestCase(7, ExpectedResult = 81)]
        [TestCase(8, ExpectedResult = 127)]
        [TestCase(9, ExpectedResult = 91)]
        [TestCase(10, ExpectedResult = -1)]
        public int SevenSegmentConverterTests(int actual)
        {
            return SevenSegmentNumber(actual);
        }
    }
}