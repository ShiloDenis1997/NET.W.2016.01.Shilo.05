using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Logic.Tests
{
    [TestFixture]
    class SorterTwinTests
    {
        #region SortByRowMinPositiveTestData
        public static IEnumerable<TestCaseData> SortByRowMinPositiveTestData
        {
            get
            {
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {15},
                    null,
                    null,
                    new long[] {1, 12, 13},
                    new long[] {10, 10},
                    null,
                    null,
                },
                new[]
                {
                    new long[] {1, 12, 13},
                    new long[] {10, 10},
                    new long[] {15},
                    null,
                    null,
                    null,
                    null
                },
                new RowMinComparatorAscending())
                .SetDescription("Test with null rows ascending.");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {15},
                    new long[] {1, 12, 13},
                    new long[] {10, 10}
                },
                new[]
                {
                    new long[] {1, 12, 13},
                    new long[] {10, 10},
                    new long[] {15}
                },
                new RowMinComparatorAscending())
                .SetDescription("Test ascending. Mix order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1, 2, 30},
                    new long[] {10},
                    new long[] {20, 20}
                },
                new[]
                {
                    new long[] {1, 2, 30},
                    new long[] {10},
                    new long[] {20, 20},
                },
                new RowMinComparatorAscending())
                .SetDescription("Test ascending. Right order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {20, 20},
                    new long[] {2, 2, 30},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {1},
                    new long[] {2, 2, 30},
                    new long[] {20, 20}
                },
                new RowMinComparatorAscending())
                .SetDescription("Test ascending. Reversed order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1},
                    new long[] {3, 2, 30},
                    new long[] {20, 20}
                },
                new[]
                {
                    new long[] {20, 20},
                    new long[] {3, 2, 30},
                    new long[] {1}
                },
                new RowMinComparatorDescending())
                .SetDescription("Test descending. Reverse order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {20, 20},
                    new long[] {3, 2, 30},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {20, 20},
                    new long[] {3, 2, 30},
                    new long[] {1}
                },
                new RowMinComparatorDescending())
                .SetDescription("Test descending. Right order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {20, 20},
                    null,
                    null,
                    new long[] {3, 2, 30},
                    null,
                    new long[] {1}
                },
                new[]
                {
                    new long[] {20, 20},
                    new long[] {3, 2, 30},
                    new long[] {1},
                    null,
                    null,
                    null
                },
                new RowMinComparatorDescending())
                .SetDescription("Test with null rows descending.");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {3, 2, 30},
                    new long[] {20, 20},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {20, 20},
                    new long[] {3, 2, 30},
                    new long[] {1}
                },
                new RowMinComparatorDescending())
                .SetDescription("Test descending. Mixed order of rows");
            }
        }
        #endregion

        #region SortByRowMinNegativeTestData
        public static IEnumerable<TestCaseData> SortByRowMinNegativeTestData
        {
            get
            {
                yield return new TestCaseData
                        (null, typeof(ArgumentNullException),
                        new RowMinComparatorAscending())
                    .SetDescription("Matrix is null");
                yield return new TestCaseData
                        (new long[][] { }, typeof(ArgumentNullException),
                        null)
                    .SetDescription("Comparer is null");
            }
        }
        #endregion

        [Test, TestCaseSource(nameof(SortByRowMinNegativeTestData))]
        public void SortTwinWithDelegateByRowMin_JaggedArray_ExceptionExpected(long[][] matrix,
            Type expectedException, IComparer<long[]> comparator)
        {
            Assert.Throws(expectedException,
                () => {
                    SorterTwin.BubbleSort(matrix, comparator == null
                ? (Comparison<long[]>)null
                : comparator.Compare);
                });
        }

        [Test]
        public void SortTwinWithDelegateByRowMin_JaggedArray_ArgumentNullExceptionExpected()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => { SorterTwin.BubbleSort(new long[][] { }, (Comparison<long[]>)null); });
        }

        [Test, TestCaseSource(nameof(SortByRowMinPositiveTestData))]
        public void SortTwinByRowMin_JaggedArray_SortedJuggedArrayExpected(long[][] matrix,
           long[][] expectedMatrix, IComparer<long[]> comparer)
        {
            Sorter.BubbleSort(matrix, comparer.Compare);
            Assert.AreEqual(expectedMatrix.Length, matrix.Length,
                "Expected and actual matrixes have a different number of rows");
            for (int i = 0; i < matrix.Length; i++)
            {
                if (expectedMatrix[i] == null && matrix[i] == null)
                    continue;
                if (expectedMatrix[i] == null)
                    Assert.Fail($"Expected null, but found {matrix[i]}");
                Assert.AreEqual(expectedMatrix[i].Length, matrix[i].Length,
                    "Length of actual matrix is differ from expected");
                for (int j = 0; j < matrix[i].Length; j++)
                    Assert.AreEqual(expectedMatrix[i][j], matrix[i][j],
                        "Element in actual matrix is differ from expected");
            }
        }
    }
}
