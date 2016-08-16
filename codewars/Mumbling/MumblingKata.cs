using System;
using System.Collections.Generic;

namespace codewars.Mumbling
{
    internal class MumblingKata
    {
        public static String Accum(string s)
        {
            var returnStringList = new List<string>();

            var i = 0;
            foreach (char c in s.ToCharArray())
            {
                returnStringList.Add(c.ToString().ToUpperInvariant() + new String(c, i++).ToLowerInvariant());
            }

            return String.Join("-", returnStringList);
        }
    }
}