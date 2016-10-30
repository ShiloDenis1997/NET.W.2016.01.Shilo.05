using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Task2.Logic.Tests
{
    [TestFixture]
    public class SorterTests
    {
        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData
                    (new []
                {
                    new long[] {1, 2, 3},
                    new long[] {1, 2},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {1},
                    new long[] {1, 2},
                    new long[] {1, 2, 3}
                });
            }
        }
        //[TestCase(new long[][] {new long[] {1}, new long[] {2}, new long[] {3}})]
        [Test, TestCaseSource(nameof(TestData))]
        public void Sort_JaggedArray_SortedJuggedArrayExpected(long[][] input,
            long[][] expectedMatrix)
        {
            long[][] actual = input.SortByRowSum();
            Assert.AreEqual(expectedMatrix.Length, actual.Length,
                "Expected and actual matrixes have a different number of rows");
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expectedMatrix[i].Length, actual[i].Length,
                    "Length of actual matrix is differ from expected");
                for (int j = 0; j < actual[i].Length; j++)
                    Assert.AreEqual(expectedMatrix[i][j], actual[i][j],
                        "Element in actual matrix is differ from expected");
            }
        }
    }
}
