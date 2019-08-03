using System;
using System.Collections.Generic;

namespace Tcgv.CombinatorialOptimization.KnapsackProblem
{
    public class RecursiveBruteForceSolver : KnapsackSolver
    {
        public RecursiveBruteForceSolver()
        {
            map = new Dictionary<int, int>();
        }

        public int Solve(Bag[] bags, int capacity)
        {
            if (map.ContainsKey(capacity))
                return map[capacity];

            var max = 0;
            
            foreach (var bag in bags)
            {
                var c = capacity - bag.Weight;
                if (c >= 0)
                {
                    var m = Solve(bags, c) + bag.Value;
                    max = Math.Max(m, max);
                }
            }

            if (!map.ContainsKey(capacity))
                map.Add(capacity, max);
            return max;
        }

        private Dictionary<int, int> map;
    }
}