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
        }

        public int Solve()
        {
            var max = -1;
            var quantities = new int[bags.Length];

            while (!IsLastCombination(quantities))
            {
                Increase(quantities);
                if (IsValidCombination(quantities))
                {
                    var r = CalculateValue(quantities);
                    max = Math.Max(r, max);
                }
            }

            return max;
        }

        private bool IsLastCombination(int[] quantities)
        {
            for (var i = 0; i < bags.Length; i++)
            {
                if (quantities[i] < capacity / bags[i].Weight)
                    return false;
            }
            return true;
        }

        private void Increase(int[] quantities)
        {
            for (var i = 0; i < bags.Length; i++)
            {
                if (quantities[i] < capacity / bags[i].Weight)
                {
                    quantities[i]++;
                    break;
                }
                else
                {
                    quantities[i] = 0;
                }
            }
        }

        private bool IsValidCombination(int[] quantities)
        {
            return CalculateWeight(quantities) <= capacity;
        }

        private int CalculateValue(int[] quantities)
        {
            var sum = 0;
            for (var i = 0; i < bags.Length; i++)
            {
                sum += bags[i].Value * quantities[i];
            }
            return sum;
        }

        private int CalculateWeight(int[] quantities)
        {
            var sum = 0;
            for (var i = 0; i < bags.Length; i++)
            {
                sum += bags[i].Weight * quantities[i];
            }
            return sum;
        }

        private Bag[] bags;
        private int capacity;
    }
}
