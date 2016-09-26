using System;
using NUnit.Framework;

namespace codewars.ToRomanNumerals
{
    /**
     * Schreibe eine Funktion, die Dezimalzahlen in Römische Zahlen übersetzt.
*
*    Beispiele:
*
*    1 -> „I“
*    2 -> „II“
*    4 -> „IV“
*    5 -> „V“
*    9 -> „IX“
*    10 -> „X“
*    42 -> „XLII“
*    99 -> „XCIX“
*    2013 -> „MMXIII“
*    Die Dezimalzahlen bewegen sich im Bereich 1 bis 3000.
*/

    public class ToRomanNumeralsTests
    {
        [Test]
        [TestCase(0, ExpectedResult = "")]
        [TestCase(1, ExpectedResult = "I")]
        [TestCase(2, ExpectedResult = "II")]
        [TestCase(3, ExpectedResult = "III")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(5, ExpectedResult = "V")]
        [TestCase(6, ExpectedResult = "VI")]
        [TestCase(7, ExpectedResult = "VII")]
        [TestCase(8, ExpectedResult = "VIII")]
        [TestCase(9, ExpectedResult = "IX")]
        [TestCase(10, ExpectedResult = "X")]
        [TestCase(11, ExpectedResult = "XI")]
        [TestCase(12, ExpectedResult = "XII")]
        [TestCase(13, ExpectedResult = "XIII")]
        [TestCase(14, ExpectedResult = "XIV")]
        [TestCase(15, ExpectedResult = "XV")]
        [TestCase(16, ExpectedResult = "XVI")]
        [TestCase(17, ExpectedResult = "XVII")]
        [TestCase(18, ExpectedResult = "XVIII")]
        [TestCase(19, ExpectedResult = "XIX")]
        [TestCase(20, ExpectedResult = "XX")]
        [TestCase(42, ExpectedResult = "XLII")]
        [TestCase(49, ExpectedResult = "XLIX")]
        [TestCase(99, ExpectedResult = "XCIX")]
        [TestCase(1000, ExpectedResult = "M")]
        [TestCase(2013, ExpectedResult = "MMXIII")]
        [TestCase(2999, ExpectedResult = "MMCMXCIX")]
        [TestCase(3000, ExpectedResult = "MMM")]
        [TestCase(3001, ExpectedResult = "")]
        public string ToRomanNumerals_Test(int value) => ToRomanNumeralsKata.ParseInt(value);
    }
}