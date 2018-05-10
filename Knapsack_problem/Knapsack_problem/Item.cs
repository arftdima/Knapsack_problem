using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problem
{
    public class Item : IComparable
    {      
        public Double Weight { get; set; }
        public Double Price { get; set; }

        public Item(Double weight, Double price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        public int CompareTo(object obj)
        {
            var a = obj as Item;
            return (Weight / Price).CompareTo(a.Weight / a.Price);
        }
    }
}
