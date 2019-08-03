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
            var bags = new[] {
                new Bag(value: 175, weight: 65),
                new Bag(value: 170, weight: 60),
                new Bag(value: 230, weight: 80),
                new Bag(value: 260, weight: 90),
                new Bag(value: 690, weight: 210)
            };

            var capacity = 760;
            var expected = 2420;
            var actual = solver.Solve(bags, capacity);

            Assert.AreEqual(expected, actual);
        }

        private void DataSet_2_Test(KnapsackSolver solver)
        {
            var bags = new[] {
                new Bag(value: 25, weight: 20),
                new Bag(value: 63, weight: 32),
                new Bag(value: 70, weight: 35),
                new Bag(value: 61, weight: 50),
                new Bag(value: 89, weight: 48),
                new Bag(value: 99, weight: 50),
                new Bag(value: 103, weight: 51)
            };

            var capacity = 120;
            var expected = 239;
            var actual = solver.Solve(bags, capacity);

            Assert.AreEqual(expected, actual);
        }
    }
}
