using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knapsack_problem;

namespace GreedyAlgorithm.Knapsack_problem
{
    public class Knapsack : AbstractKnapsack
    {
        private List<Item> bestItems;
        private Double maxW;
        
        public Knapsack(Double maxw) { this.maxW = maxw; bestItems = new List<Item>(); NameMethod = "GreedyAlgorithm"; }

        public override void MakeAllSets(List<Item> list)
        {
            list.Sort();
            var sum = 0d;
            foreach(var i in list)
            {
                sum += i.Weight;
                if (sum <= maxW) bestItems.Add(i);
                else break;
            }
            bestItems.ForEach(x => bestPrice += x.Price);
        }

        public override List<Item> GetBestItems()
        {
            return bestItems;
        }
    }
}
