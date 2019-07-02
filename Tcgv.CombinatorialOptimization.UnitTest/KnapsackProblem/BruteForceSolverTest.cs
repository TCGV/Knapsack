using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tcgv.CombinatorialOptimization.KnapsackProblem;

namespace Tcgv.CombinatorialOptimization.UnitTest.KnapsackProblem
{
    [TestClass]
    public class BruteForceSolverTest
    {
        // Data set from https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/
        
        [TestMethod]
        public void DataSetTest()
        {
            var bags = new [] {
                new Bag(value: 60, weight: 100),
                new Bag(value: 100, weight: 20),
                new Bag(value: 120, weight: 30)
            };

            var capacity = 50;
            var solver = new BruteForceSolver(bags, capacity);

            var expected = 220;
            var actual = solver.Solve();
            Assert.AreEqual(expected, actual);
        }
    }
}
