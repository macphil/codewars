using System;
using System.Collections.Generic;

namespace codewars.ToRomanNumerals
{
    internal class ToRomanNumeralsKata
    {
        internal static string ParseInt(int value)
        {
            if (value < 1 || value > 3000)
            {
                return string.Empty;
            }

            var romanNumber = string.Empty;

            romanNumber += new string('M', Convert.ToInt32(value / 1000));
            value = value % 1000;
            romanNumber += new string('D', Convert.ToInt32(value / 500));
            value = value % 500;
            romanNumber += new string('C', Convert.ToInt32(value / 100));
            value = value % 100;
            romanNumber += new string('L', Convert.ToInt32(value / 50));
            value = value % 50;
            romanNumber += new string('X', Convert.ToInt32(value / 10));
            value = value % 10;
            romanNumber += new string('V', Convert.ToInt32(value / 5));
            value = value % 5;
            romanNumber += new string('I', Convert.ToInt32(value / 1));

            romanNumber = HandleNine(romanNumber);
            romanNumber = HandleFour(romanNumber);

            return romanNumber;
        }

        private static string HandleFour(string romanNumber)
        {
            return romanNumber.Replace("IIII", "IV").Replace("XXXX", "XL");
        }

        private static string HandleNine(string romanNumber)
        {
            return romanNumber.Replace("VIIII", "IX").Replace("LXXXX", "XC");
        }
    }
}