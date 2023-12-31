﻿using System.Linq;

namespace codewars.Descending_Order
{
    public class DescendingOrderKata
    {
        public static int DescendingOrder(int num)
        {
            return (num < 10) ? num : int.Parse(string.Concat(num.ToString().OrderByDescending(x => x)));
        }
    }
}