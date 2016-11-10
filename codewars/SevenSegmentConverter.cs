using System;
using NUnit.Framework;

namespace codewars
{
    public enum OnOff
    {
        Off = 0,
        On = 1
    }

    public static class OnOffExtensions
    {
        public static char X(this OnOff onOffValue) => onOffValue == OnOff.On ? '#' : ' ';
    }

    /*
   *
       The bits for each segment are in the following order,
       from right to left: (Binary always reads from right to left!)

       7_Top Horizontal
       6_Middle Horizontal
       5_Bottom Horizontal
       4_Top-Left Vertical
       3_Top-Right Vertical
       2_Bottom-Left Vertical
       1_Bottom-Right Vertical
   */

    public class SevenSegment
    {
        public SevenSegment Four => new SevenSegment
        {
            TopLeftVertical = OnOff.On,
            MiddleHorizontal = OnOff.On,
            TopRightVertical = OnOff.On,
            BottomRightVertical = OnOff.On
        };

        public SevenSegment One => new SevenSegment
        {
            TopRightVertical = OnOff.On,
            BottomRightVertical = OnOff.On
        };

        private OnOff BottomHorizontal { get; set; } = OnOff.Off;

        private OnOff BottomLeftVertical { get; set; } = OnOff.Off;

        private OnOff BottomRightVertical { get; set; } = OnOff.Off;

        private OnOff MiddleHorizontal { get; set; } = OnOff.Off;

        private OnOff TopHorizontal { get; set; } = OnOff.Off;

        private OnOff TopLeftVertical { get; set; } = OnOff.Off;

        private OnOff TopRightVertical { get; set; } = OnOff.Off;

        public override string ToString()
        {
            var middle = new string(' ', 3);
            var asciArt = $"" +
                $"{new string(TopHorizontal.X(), 5)}\n" +
                $"{TopLeftVertical.X()}{middle}{TopRightVertical.X()}\n" +
                $"{TopLeftVertical.X()}{middle}{TopRightVertical.X()}\n" +
                $"{new string(MiddleHorizontal.X(), 5)}\n" +
                $"{BottomLeftVertical.X()}{middle}{BottomRightVertical.X()}\n" +
                $"{BottomLeftVertical.X()}{middle}{BottomRightVertical.X()}\n" +
                $"{new string(BottomHorizontal.X(), 5)}\n";

            return asciArt;
        }

        private void xSevenSegment(
            OnOff bottom_right_vertical,
            OnOff bottom_left_vertical,
            OnOff top_right_vertical,
            OnOff top_left_vertical,
            OnOff bottom_horizontal,
            OnOff middle_horizontal,
            OnOff top_horizontal)
        {
            BottomHorizontal = bottom_horizontal;
            BottomLeftVertical = bottom_left_vertical;
            BottomRightVertical = bottom_right_vertical;
            MiddleHorizontal = middle_horizontal;
            TopHorizontal = top_horizontal;
            TopLeftVertical = top_left_vertical;
            TopRightVertical = top_right_vertical;
        }
    }

    // https://www.codewars.com/kata/7-segment-converter/csharp
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
            Console.WriteLine(new SevenSegment().Four.ToString());
            return SevenSegmentNumber(actual);
        }
    }
}