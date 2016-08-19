using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

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

            var builder = new System.Text.StringBuilder();

            foreach (KeyValuePair<int, string> romanSign in RomanSigns.Reverse().Where(romanSign => Convert.ToInt32(value / romanSign.Key) > 0))
            {
                var anz = Convert.ToInt32(value / romanSign.Key);

                builder.Append(RomanRepresentation(romanSign, anz));

                value = value % romanSign.Key;
            }
            return builder.ToString();
        }

        private static string RomanRepresentation(KeyValuePair<int, string> romanSign, int anz)
        {
            return (romanSign.Value.Length == 1) ?
                new string(romanSign.Value.ToCharArray()[0], anz)
                : romanSign.Value;
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
    }
}