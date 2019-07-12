using System;

namespace Tcgv.CombinatorialOptimization.KnapsackProblem
{
    // Time complexity is O(2 ^ n)
    // Space complexity is O(m)
    //
    // Where "n" is bounded by the minimum and maximum values for
    // each bag relation of: Capacity / Bag Weight
    //
    // Where "m" is the length of the "bags" array, i.e., it's the
    // number of different kind of bags available for solving the
    // problem
    //
    // Note: This is a naive, inneficient solution to the problem,
    // but an iterative one, that doesn't rely on recursion
    public class BruteForceSolver
    {
        public BruteForceSolver(Bag[] bags, int capacity)
        {
            this.bags = bags;
            this.capacity = capacity;
            this.quantities = new int [bags.Length];
            this.weight = 0;
            this.value = 0;
        }

        public int Solve()
        {
            var max = -1;

            while (Increase(quantities))
            {
                if (this.weight <= capacity)
                {
                    max = Math.Max(this.value, max);
                }
            }

            return max;
        }

        private bool Increase(int[] quantities)
        {
            var increased = false;

            for (var i = 0; i < bags.Length; i++)
            {
                if (quantities[i] < capacity / bags[i].Weight)
                {
                    quantities[i]++;
                    weight += bags[i].Weight;
                    value += bags[i].Value;
                    increased = true;
                    break;
                }
                else
                {
                    weight -= bags[i].Weight * quantities[i];
                    value -= bags[i].Value * quantities[i];
                    quantities[i] = 0;
                }
            }

            return increased;
        }

        private Bag[] bags;
        private int capacity;

        private int[] quantities;
        private int weight;
        private int value;
    }
}
