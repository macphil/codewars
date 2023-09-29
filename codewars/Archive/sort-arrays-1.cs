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
            Assert.That(string.Join(",", SortMe(new[] { "one", "two", "three" })), Is.EqualTo("one,three,two"));
        }

        private string[] SortMe(string[] names)
        {
            return names.OrderBy(x => x).ToArray();
        }
    }
}