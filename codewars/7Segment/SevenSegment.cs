using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codewars._7Segment
{
    public enum SevenSegmentLED
    {
        TopHorizontal = 1,
        MiddleHorizontal = 2,
        BottomHorizontal = 4,
        TopLeftVertical = 8,
        TopRightVertical = 16,
        BottomLeftVertical = 32,
        BottomRightVertical = 64
    }

    public class SevenSegment
    {
        private readonly List<SevenSegmentLED> _activeSegments;

        public SevenSegment(List<SevenSegmentLED> activeSegments)
        {
            _activeSegments = activeSegments;
        }

        public static SevenSegment Nr0 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopHorizontal, SevenSegmentLED.TopRightVertical, SevenSegmentLED.BottomRightVertical, SevenSegmentLED.BottomHorizontal, SevenSegmentLED.BottomLeftVertical, SevenSegmentLED.TopLeftVertical});

        public static SevenSegment Nr1 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopRightVertical, SevenSegmentLED.BottomRightVertical });

        public static SevenSegment Nr2 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopHorizontal, SevenSegmentLED.TopRightVertical, SevenSegmentLED.MiddleHorizontal, SevenSegmentLED.BottomLeftVertical, SevenSegmentLED.BottomHorizontal });

        public static SevenSegment Nr3 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopHorizontal, SevenSegmentLED.TopRightVertical, SevenSegmentLED.MiddleHorizontal, SevenSegmentLED.BottomRightVertical, SevenSegmentLED.BottomHorizontal });

        public static SevenSegment Nr4 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopLeftVertical, SevenSegmentLED.MiddleHorizontal, SevenSegmentLED.TopRightVertical, SevenSegmentLED.BottomRightVertical });

        public static SevenSegment Nr5 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopHorizontal, SevenSegmentLED.TopLeftVertical, SevenSegmentLED.MiddleHorizontal, SevenSegmentLED.BottomRightVertical, SevenSegmentLED.BottomHorizontal});

        public static SevenSegment Nr6 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopHorizontal, SevenSegmentLED.TopLeftVertical, SevenSegmentLED.MiddleHorizontal, SevenSegmentLED.BottomRightVertical, SevenSegmentLED.BottomHorizontal, SevenSegmentLED.BottomLeftVertical});

        public static SevenSegment Nr7 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopHorizontal, SevenSegmentLED.TopRightVertical, SevenSegmentLED.BottomRightVertical });

        public static SevenSegment Nr8 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopHorizontal, SevenSegmentLED.TopRightVertical, SevenSegmentLED.BottomRightVertical, SevenSegmentLED.BottomHorizontal, SevenSegmentLED.BottomLeftVertical, SevenSegmentLED.TopLeftVertical, SevenSegmentLED.MiddleHorizontal});

        public static SevenSegment Nr9 => new SevenSegment(new List<SevenSegmentLED>
        {SevenSegmentLED.TopHorizontal, SevenSegmentLED.TopRightVertical, SevenSegmentLED.MiddleHorizontal, SevenSegmentLED.TopLeftVertical, SevenSegmentLED.BottomRightVertical, SevenSegmentLED.BottomHorizontal});

        public override string ToString()
        {
            var asciiArt = new StringBuilder();
            var o = new string(' ', 3);

            asciiArt.Append(GetChar(SevenSegmentLED.TopLeftVertical));
            asciiArt.Append(new string(GetChar(SevenSegmentLED.TopHorizontal), 3));
            asciiArt.Append(GetChar(SevenSegmentLED.TopRightVertical));
            asciiArt.AppendLine();

            asciiArt.Append(GetChar(SevenSegmentLED.TopLeftVertical));
            asciiArt.Append(o);
            asciiArt.Append(GetChar(SevenSegmentLED.TopRightVertical));
            asciiArt.AppendLine();

            asciiArt.Append(GetChar(SevenSegmentLED.TopLeftVertical));
            asciiArt.Append(o);
            asciiArt.Append(GetChar(SevenSegmentLED.TopRightVertical));
            asciiArt.AppendLine();

            asciiArt.Append(GetChar(SevenSegmentLED.BottomLeftVertical));
            asciiArt.Append(new string(GetChar(SevenSegmentLED.MiddleHorizontal), 3));
            asciiArt.Append(GetChar(SevenSegmentLED.BottomRightVertical));
            asciiArt.AppendLine();

            asciiArt.Append(GetChar(SevenSegmentLED.BottomLeftVertical));
            asciiArt.Append(o);
            asciiArt.Append(GetChar(SevenSegmentLED.BottomRightVertical));
            asciiArt.AppendLine();

            asciiArt.Append(GetChar(SevenSegmentLED.BottomLeftVertical));
            asciiArt.Append(o);
            asciiArt.Append(GetChar(SevenSegmentLED.BottomRightVertical));
            asciiArt.AppendLine();

            asciiArt.AppendLine(new string(GetChar(SevenSegmentLED.BottomHorizontal), 5));

            return asciiArt.ToString();
        }

        public int Value()
        {
            Console.WriteLine(this.ToString());
            return _activeSegments.Sum(x => (int)x);
        }

        private char GetChar(SevenSegmentLED led)
        {
            return _activeSegments.Contains(led) ? '#' : ' ';
        }
    }
}