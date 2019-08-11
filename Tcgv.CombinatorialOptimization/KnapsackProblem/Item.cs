namespace Tcgv.CombinatorialOptimization.KnapsackProblem
{
    public class Item
    {
        public Item(int value, int weight)
        {
            this.Value = value;
            this.Weight = weight;
        }

        public int Value { get; private set; }

        public int Weight { get; private set; }
    }
}