using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace codewars
{
    [TestFixture()]
    public class GreedyThiefTetst
    {
        [Test(), Ignore("nyi")]
        public void FirstExample()
        {
            // arrange
            var arrangedItems = new List<Item>
            {
                new Item(2, 6),
                new Item(2, 3),
                new Item(6, 5),
                new Item(5, 4),
                new Item(4, 6)
            };

            // act
            var stolen = KataGreedyThief.GreedyThief(arrangedItems, 10);

            //assert

            //  greedyThief(items, n) can be:
            //[
            // {weight:2, price:6},
            // {weight:2, price:3},
            // {weight:4, price:6}
            //]

            Assert.That(stolen, Has.Count.EqualTo(3));
            Assert.That(stolen.Sum(x => x.Weight), Is.LessThanOrEqualTo(10));
            Assert.Pass();
        }

        [Test]
        public void TestNoItemLighterThenMaxWeight()
        {
            // arrange
            var arrangedItems = new List<Item>
            {
                new Item(5, 0),
                new Item(4, 0),
                new Item(6, 0)
            };

            // act
            var stolen = KataGreedyThief.GreedyThief(arrangedItems, 3);

            // assert
            Assert.That(stolen, Has.Count.EqualTo(0));

        }
    }
}
