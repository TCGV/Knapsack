using System;

namespace Tcgv.CombinatorialOptimization.KnapsackProblem
{
    public class IterativeBruteForceSolver : KnapsackSolver
    {
        public int Solve(Bag[] bags, int capacity)
        {
            var max = -1;

            SetVariables(bags, capacity);

            while (Increase(quantities))
            {
                if (this.weight <= capacity)
                {
                    max = Math.Max(this.value, max);
                }
            }

            return max;
        }
        private void SetVariables(Bag[] bags, int capacity)
        {
            this.bags = bags;
            this.capacity = capacity;
            this.quantities = new int [bags.Length];
            this.weight = 0;
            this.value = 0;
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
