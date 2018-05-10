using System;
using System.Collections.Generic;
using System.IO;

namespace Knapsack_problem
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var items = new List<Item>();

            var exmamples = new String[]
            {
                @"C:\Users\Dima\Source\Repos\Knapsack_problem\Knapsack_problem\example1.txt",
                @"C:\Users\Dima\Source\Repos\Knapsack_problem\Knapsack_problem\example1.txt"
            };

            var volume = 10;
            using (var sr = new StreamReader(exmamples[1] /*examples[0]*/, System.Text.Encoding.Default))  
            {
                var str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    var a = str.Split(',');
                    items.Add(new Item(Double.Parse(a[0]), Double.Parse(a[1])));
                }
            }


            var knapsacks = new AbstractKnapsack[] 
            {
                new FullBust.Knapsack_problem.Knapsack(volume),
                new Knapsack01.Knapsack_problem.Knapsack(volume),
                new GreedyAlgorithm.Knapsack_problem.Knapsack(volume)
            };

            foreach (var knapsack in knapsacks)
            {
                knapsack.MakeAllSets(items);
                
                Console.WriteLine($"=>{knapsack.NameMethod}\n\t--->{knapsack.bestPrice}<---\n");
                knapsack.GetBestItems().ForEach(x => Console.WriteLine($"{x.Weight} {x.Price}"));
                Console.WriteLine();
            }
        }
    }
}
