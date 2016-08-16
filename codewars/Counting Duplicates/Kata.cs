using System.Linq;
using System.Xml.Serialization;

namespace codewars.Counting_Duplicates
{
    public class Kata
    {
        public static int DuplicateCount(string str)
        {
            var count = 0;
            str = str.ToLowerInvariant();

            foreach (char c in str.ToCharArray().OrderBy(s => s).Distinct())
            {
                if (Enumerable.Where(str.ToCharArray(), s => s.Equals(c)).Count() > 1)
                {
                    count++;
                }
            }
          return count;
        }
    }
}