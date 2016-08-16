using System;
using System.Linq;

namespace codewars.Mumbling
{
    internal class MumblingKata
    {
        public static String Accum(string s)
        {
            return string.Join("-", s.Select((x, i) => char.ToUpper(x) + new string(char.ToLower(x), i)));
        }
    }
}