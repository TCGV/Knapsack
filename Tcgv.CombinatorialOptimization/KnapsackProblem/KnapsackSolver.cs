namespace Tcgv.CombinatorialOptimization.KnapsackProblem
{
    public interface KnapsackSolver
    {
         int Solve(Item[] items, int capacity);
    }
}