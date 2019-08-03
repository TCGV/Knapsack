namespace Tcgv.CombinatorialOptimization.KnapsackProblem
{
    public interface KnapsackSolver
    {
         int Solve(Bag[] bags, int capacity);
    }
}