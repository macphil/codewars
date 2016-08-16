using System.Linq;

namespace codewars.Counting_Duplicates
{
    public class Kata
    {
        public static int DuplicateCount(string str)
        {
            return str.ToLower().GroupBy(c => c).Count(g => g.Count() > 1);
        }
    }
}