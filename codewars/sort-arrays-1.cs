using System;
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
            return names;
        }
    }
}