using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;

namespace codewars.Descending_Order
{
    public class Kata
    {
        public static int DescendingOrder(int num)
        {
            // Bust a move right here
            if (num < 10)
            {
                return num;
            }

            var numAsCharArray = num.ToString().ToCharArray();

            var sortedString = new string(numAsCharArray.OrderByDescending(s => s).ToArray());

            return Int32.Parse(sortedString.ToString());

        }
    }
}