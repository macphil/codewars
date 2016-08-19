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
        [TestCase(1, ExpectedResult = "I")]
        [TestCase(2, ExpectedResult = "II")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(5, ExpectedResult = "V")]
        [TestCase(9, ExpectedResult = "IX")]
        [TestCase(10, ExpectedResult = "X")]
        [TestCase(42, ExpectedResult = "XLII")]
        [TestCase(99, ExpectedResult = "XCIX")]
        [TestCase(2013, ExpectedResult = "MMXIII")]
        [TestCase(1000, ExpectedResult = "M")]
        public string ToRomanNumerals_Test(int value) => ToRomanNumeralsKata.ParseInt(value);
    }
}