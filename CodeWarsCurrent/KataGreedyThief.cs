﻿// see https://www.codewars.com/kata/greedy-thief

namespace codewars
{
    using System.Collections.Generic;
    using System.Linq;

    public class Item
    {
        public int Weight { get; set; }

        public int Price { get; set; }

        public string ItemName => ToString();

        public Item(int weight, int price)
        {
            Weight = weight;
            Price = price;
        }

        public override string ToString()
        {
            return $"weight: {Weight}kg, price: {Price}$";
        }

    }


    public class KataGreedyThief
    {
        public static List<Item> GreedyThief(List<Item> potentialItems, int maxWeight)
        {
            var stolen = new List<Item>();
            if (potentialItems.Min(x => x.Weight) > maxWeight)
            {
                return stolen;
            }
            var notTooHeavyItems = potentialItems.Where(x => x.Weight <= maxWeight);

            stolen.Add(notTooHeavyItems.OrderByDescending(x => (double)x.Price / (double)x.Weight).First());

            return stolen;
        }
    }
}
