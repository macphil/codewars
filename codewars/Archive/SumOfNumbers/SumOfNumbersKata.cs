using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codewars.SumOfNumbers
{
    internal class SumOfNumbersKata
    {
        public static int GetSum(int a, int b)
        {
            int sum = 0;
            for (int i = Math.Min(a, b); i <= Math.Max(a, b); i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}