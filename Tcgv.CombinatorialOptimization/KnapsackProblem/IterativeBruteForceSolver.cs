using System;

namespace Tcgv.CombinatorialOptimization.KnapsackProblem
{
    public class IterativeBruteForceSolver : KnapsackSolver
    {
        public int Solve(Item[] items, int capacity)
        {
            var max = -1;

            SetVariables(items, capacity);

            while (Increase(quantities))
            {
                if (this.weight <= capacity)
                {
                    max = Math.Max(this.value, max);
                }
            }

            return max;
        }
        private void SetVariables(Item[] items, int capacity)
        {
            this.items = items;
            this.capacity = capacity;
            this.quantities = new int [items.Length];
            this.weight = 0;
            this.value = 0;
        }

        private bool Increase(int[] quantities)
        {
            var increased = false;

            for (var i = 0; i < items.Length; i++)
            {
                if (quantities[i] < capacity / items[i].Weight)
                {
                    quantities[i]++;
                    weight += items[i].Weight;
                    value += items[i].Value;
                    increased = true;
                    break;
                }
                else
                {
                    weight -= items[i].Weight * quantities[i];
                    value -= items[i].Value * quantities[i];
                    quantities[i] = 0;
                }
            }

            return increased;
        }

        private Item[] items;
        private int capacity;

        private int[] quantities;
        private int weight;
        private int value;
    }
}
