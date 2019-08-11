using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tcgv.CombinatorialOptimization.KnapsackProblem;

namespace Tcgv.CombinatorialOptimization.UnitTest.KnapsackProblem
{
    // Data sets extracted from http://vuir.vu.edu.au/17924/1/IYER_1997compressed.pdf
    [TestClass]
    public class BruteForceSolverTest
    {        
        [TestMethod]
        public void IterativeBruteForceSolverTest()
        {
            DataSet_1_Test(new IterativeBruteForceSolver());
            DataSet_2_Test(new IterativeBruteForceSolver());
        }

        [TestMethod]
        public void RecursiveDynamicSolverTest()
        {
            DataSet_1_Test(new RecursiveDynamicSolver());
            DataSet_2_Test(new RecursiveDynamicSolver());
        }

        private void DataSet_1_Test(KnapsackSolver solver)
        {
            var items = new[] {
                new Item(value: 175, weight: 65),
                new Item(value: 170, weight: 60),
                new Item(value: 230, weight: 80),
                new Item(value: 260, weight: 90),
                new Item(value: 690, weight: 210)
            };

            var capacity = 760;
            var expected = 2420;
            var actual = solver.Solve(items, capacity);

            Assert.AreEqual(expected, actual);
        }

        private void DataSet_2_Test(KnapsackSolver solver)
        {
            var items = new[] {
                new Item(value: 25, weight: 20),
                new Item(value: 63, weight: 32),
                new Item(value: 70, weight: 35),
                new Item(value: 61, weight: 50),
                new Item(value: 89, weight: 48),
                new Item(value: 99, weight: 50),
                new Item(value: 103, weight: 51)
            };

            var capacity = 120;
            var expected = 239;
            var actual = solver.Solve(items, capacity);

            Assert.AreEqual(expected, actual);
        }
    }
}
