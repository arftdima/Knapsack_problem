using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knapsack_problem;

namespace Knapsack01.Knapsack_problem
{
    public class Knapsack : AbstractKnapsack
    {
        private List<Item> bestItems;
        private Double capacity;

        public Knapsack(Double capacity) { this.capacity = capacity; NameMethod = "KnapsackClassic"; }

        public override void MakeAllSets(List<Item> list)
        {
            var goods = new Tuple<int, int>[list.Count];
            var indx = 0;
            list.ForEach(q => goods[indx++] = new Tuple<int, int>((int)q.Weight, (int)q.Price));

            var n = list.Count - 1;
            var m = (int)capacity;
            var kn = new int[n + 1, m + 1];

            for (var i = 1; i <= n; ++i)
            {
                var w = goods[i].Item1;
                var c = goods[i].Item2;
                if (w > capacity) continue;

                for (var j = 0; j < w; ++j)
                    kn[i, j] = kn[i - 1, j];
                for (var j = w; j <= m; ++j)
                    kn[i, j] = Math.Max(kn[i - 1, j - w] + c, kn[i - 1, j]);
            }
            bestPrice = kn[n, m];

            Stack<int> taken = new Stack<int>();
            int x = n, y = m;
            while (x != 0)
            {
                if (kn[x, y] != kn[x - 1, y])
                {
                    taken.Push(x);
                    y -= goods[x].Item1;
                    --x;
                }
                else --x;
            }

            bestItems = new List<Item>();
            if (taken.Count == 0) Console.WriteLine("no items");
            else while (taken.Count != 0) bestItems.Add(new Item(goods[taken.Peek()].Item1, goods[taken.Pop()].Item2));

        }

        public override List<Item> GetBestItems()
        {
            return bestItems;
        }
    }
}
