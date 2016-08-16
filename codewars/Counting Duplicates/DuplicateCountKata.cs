using System.Linq;

namespace codewars.Counting_Duplicates
{
    public class DuplicateCountKata
    {
        public static int DuplicateCount(string str)
        {
            return str.ToLower().GroupBy(c => c).Count(g => g.Count() > 1);
        }
    }
}