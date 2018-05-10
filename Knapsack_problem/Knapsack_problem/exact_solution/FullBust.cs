using System;
using System.Collections.Generic;
using System.Linq;
using Knapsack_problem;

namespace FullBust.Knapsack_problem //n!
{
    public class Knapsack : AbstractKnapsack
    {
        private List<Item> bestItems;
        private Double maxW;

        public Knapsack(Double maxw) { this.maxW = maxw; NameMethod = "FullBust"; }

        private Double calcW(List<Item> list)
        {
            return list.Select(x => x.Weight).Sum();
        }
        private Double calcP(List<Item> list)
        {
            return list.Select(x => x.Price).Sum();
        }
        private void CheckSet(List<Item> list)
        {
            if (bestItems == null && maxW >= calcW(list))
            {
                bestItems = list;
                bestPrice = calcP(list);
            }
            else
            {
                if (calcW(list) <= maxW && calcP(list) > bestPrice)
                {
                    bestPrice = calcP(list);
                    bestItems = list;
                }
            }
        }


        public override void MakeAllSets(List<Item> list)
        {
            if (list.Count > 0) CheckSet(list);
            for(int i = 0; i < list.Count; ++i)
            {
                var newList = new List<Item>(list);
                newList.RemoveAt(i);

                MakeAllSets(newList);
            }
        }

        public override List<Item> GetBestItems()
        {
            return bestItems;
        }
    }
}