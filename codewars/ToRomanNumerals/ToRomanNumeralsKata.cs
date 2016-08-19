using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

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

            foreach (KeyValuePair<int, string> romanSign in RomanSigns.Reverse())
            {
                var anz = Convert.ToInt32(value / romanSign.Key);
                if (anz == 0)
                {
                    continue;
                }

                romanNumber += (romanSign.Value.Length == 1) ?
                    new string(romanSign.Value.ToCharArray()[0], anz)
                    : romanSign.Value;

                value = value % romanSign.Key;
            }

            return romanNumber;
        }

        private static Dictionary<int, string> RomanSigns
        {
            get
            {
                return new Dictionary<int, string>
                {
                    {1, "I"},
                    {4, "IV"},
                    {5, "V"},
                    {9, "IX"},
                    {10, "X"},
                    {40, "XL"},
                    {50, "L"},
                    {90, "XC"},
                    {100, "C"},
                    {400, "CD"},
                    {500, "D"},
                    {900, "CM"},
                    {1000, "M"}
                };
            }
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