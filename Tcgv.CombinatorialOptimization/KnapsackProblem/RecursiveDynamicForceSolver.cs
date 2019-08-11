using System;
using System.Collections.Generic;

namespace Tcgv.CombinatorialOptimization.KnapsackProblem
{
    public class RecursiveDynamicSolver : KnapsackSolver
    {
        public RecursiveDynamicSolver()
        {
            map = new Dictionary<int, int>();
        }

        public int Solve(Item[] items, int capacity)
        {
            if (map.ContainsKey(capacity))
                return map[capacity];

            var max = 0;
            
            foreach (var item in items)
            {
                var c = capacity - item.Weight;
                if (c >= 0)
                {
                    var m = Solve(items, c) + item.Value;
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