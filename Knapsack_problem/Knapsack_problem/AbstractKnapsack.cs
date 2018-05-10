using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problem
{
    public abstract class AbstractKnapsack
    {
        public abstract void MakeAllSets(List<Item> list);
        public abstract List<Item> GetBestItems();
        public Double bestPrice;
        public String NameMethod;
    }
}
