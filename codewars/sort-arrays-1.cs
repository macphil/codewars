using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace codewars
{
    public class sort_arrays_1
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("one,three,two", string.Join(",", SortMe(new[] { "one", "two", "three" })));
        }

        private string[] SortMe(string[] names)
        {
            var numbers = new List<int>();
            foreach (string name in names.Where(x => names.Contains(x)))
            {
                numbers.Add(Numerals.First(x => x.Value == name).Key);
            }

            var numeralsList = new List<string>();
            foreach (int number in numbers)
            {
                numeralsList.Add(Numerals[number]);
            }

            return numeralsList.ToArray();
        }

        public Dictionary<int, string> Numerals
        {
            get
            {
                return new Dictionary<int, string>
                {
                    {1, "one"},
                    {2, "two"},
                    {3, "three"},
                    {4, "four"},
                    {5, "five"},
                    {6, "six"},
                    {7, "seven"},
                    {8, "eight"},
                    {9, "nine"},
                    {10, "ten"}
                };
            }
        }
    }
}