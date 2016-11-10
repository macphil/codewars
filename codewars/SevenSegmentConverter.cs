using NUnit.Framework;

namespace codewars
{
    public class SevenSegmentConverter
    {
        public static int SevenSegmentNumber(int number)
        {
            return number;
        }

        [Test]
        [TestCase(4, ExpectedResult = 90)]
        public int SevenSegmentConverterTests(int actual)
        {
            return SevenSegmentNumber(actual);
        }
    }

    public class SevenSegment
    {
        private bool _top_horizontal;
        private bool _middle_horizontal;
        private bool _bottom_horizontal;
        private bool _top_left_vertical;
        private bool _top_right_vertical;
        private bool _bottom_left_vertical;
        private bool _bottom_right_vertical;

        public SevenSegment(
            bool bottom_right_vertical,
            bool bottom_left_vertical,
            bool top_right_vertical,
            bool top_left_vertical,
            bool bottom_horizontal,
            bool middle_horizontal,
            bool top_horizontal)
        {
            _bottom_horizontal = bottom_horizontal;
            _bottom_left_vertical = bottom_left_vertical;
            _bottom_right_vertical = bottom_right_vertical;
            _middle_horizontal = middle_horizontal;
            _top_horizontal = top_horizontal;
            _top_left_vertical = top_left_vertical;
            _top_right_vertical = top_right_vertical;
        }
    }
}