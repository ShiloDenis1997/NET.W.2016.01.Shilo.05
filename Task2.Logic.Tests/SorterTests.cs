using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Task2.Logic.Tests
{
    [TestFixture]
    public class SorterTests
    {

        #region SortByRowSumPositiveTestData
        public static IEnumerable<TestCaseData> SortByRowSumPositiveTestData
        {
            get
            {
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1},
                    null,
                    new long[] {1, 2},
                    new long[] {1, 2, 3},
                    null,
                    null
                },
                new[]
                {
                    new long[] {1},
                    new long[] {1, 2},
                    new long[] {1, 2, 3},
                    null,
                    null,
                    null
                },
                new RowSumComparatorAscending())
                .SetDescription("Test with null rows ascending.");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1},
                    new long[] {1, 2},
                    new long[] {1, 2, 3}
                },
                new[]
                {
                    new long[] {1},
                    new long[] {1, 2},
                    new long[] {1, 2, 3}
                },
                new RowSumComparatorAscending())
                .SetDescription("Test ascending. Right order of rows");
                yield return new TestCaseData
                    (new[]
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
                },
                new RowSumComparatorAscending())
                .SetDescription("Test ascending. Reverse order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1, 2},
                    new long[] {1, 2, 3},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {1},
                    new long[] {1, 2},
                    new long[] {1, 2, 3}
                },
                new RowSumComparatorAscending())
                .SetDescription("Test ascending. Mixed order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1},
                    new long[] {1, 2},
                    new long[] {1, 2, 3}
                },
                new[]
                {
                    new long[] {1, 2, 3},
                    new long[] {1, 2},
                    new long[] {1}
                },
                new RowSumComparatorDescending())
                .SetDescription("Test descending. Reverse order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1},
                    null,
                    null,
                    null,
                    new long[] {1, 2},
                    null,
                    new long[] {1, 2, 3}
                },
                new[]
                {
                    new long[] {1, 2, 3},
                    new long[] {1, 2},
                    new long[] {1},
                    null,
                    null,
                    null,
                    null,
                },
                new RowSumComparatorDescending())
                .SetDescription("Test with null rows descending. Reverse order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1, 2, 3},
                    new long[] {1, 2},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {1, 2, 3},
                    new long[] {1, 2},
                    new long[] {1}
                },
                new RowSumComparatorDescending())
                .SetDescription("Test descending. Right order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1, 2},
                    new long[] {1, 2, 3},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {1, 2, 3},
                    new long[] {1, 2},
                    new long[] {1}
                },
                new RowSumComparatorDescending())
                .SetDescription("Test descending. Mixed order of rows");
            }
        }
        #endregion

        #region SortByRowSumNegativeTestData
        public static IEnumerable<TestCaseData> SortByRowSumNegativeTestData
        {
            get
            {
                yield return new TestCaseData
                        (null, typeof(ArgumentNullException),
                        new RowSumComparatorAscending())
                    .SetDescription("Matrix is null");
                yield return new TestCaseData
                    (new[]
                {
                    new [] {long.MaxValue, long.MaxValue},
                    new long[] {1, 2, 3},
                }, typeof(OverflowException),
                        new RowSumComparatorAscending())
                .SetDescription("Sum of elements in the first row is" +
                                $"greater than {long.MaxValue}");
                yield return new TestCaseData
                    (new[]
                {
                    new [] {long.MinValue, long.MinValue},
                    new long[] {1, 2, 3},
                }, typeof(OverflowException),
                        new RowSumComparatorAscending())
                .SetDescription("Sum of elements in the first row is" +
                                $"less than {long.MinValue}");
            }
        } 
        #endregion

        [Test, TestCaseSource(nameof(SortByRowSumPositiveTestData))]
        public void SortByRowSum_JaggedArray_SortedJuggedArrayExpected(long[][] matrix,
            long[][] expectedMatrix, IComparer<long[]> comparer)
        {
            Sorter.BubbleSort(matrix, comparer);
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

        [Test, TestCaseSource(nameof(SortByRowSumNegativeTestData))]
        public void SortByRowSum_JaggedArray_ExceptionExpected(long[][] matrix,
            Type expectedException, IComparer<long[]> comparator)
        {
            Assert.Throws(expectedException, () => { Sorter.BubbleSort(matrix, comparator); });
        }

        #region SortByRowMaxPositiveTestData
        public static IEnumerable<TestCaseData> SortByRowMaxPositiveTestData
        {
            get
            {
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {15},
                    new long[] {10, 10},
                    new long[] {1, 12, 13}
                },
                new[]
                {
                    new long[] {10, 10},
                    new long[] {1, 12, 13},
                    new long[] {15}
                },
                new RowMaxComparatorAscending())
                .SetDescription("Test ascending. Mix order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {15},
                    null,
                    new long[] {10, 10},
                    null,
                    new long[] {1, 12, 13}
                },
                new[]
                {
                    new long[] {10, 10},
                    new long[] {1, 12, 13},
                    new long[] {15},
                    null,
                    null,
                },
                new RowMaxComparatorAscending())
                .SetDescription("Test with null rows ascending.");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1, 2, 30},
                    new long[] {20, 20},
                    new long[] {10}
                },
                new[]
                {
                    new long[] {10},
                    new long[] {20, 20},
                    new long[] {1, 2, 30}
                },
                new RowMaxComparatorAscending())
                .SetDescription("Test ascending. Reverse order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {20, 20},
                    new long[] {1, 2, 30},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {1},
                    new long[] {20, 20},
                    new long[] {1, 2, 30}
                },
                new RowMaxComparatorAscending())
                .SetDescription("Test ascending. Mixed order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1},
                    new long[] {20, 20},
                    new long[] {1, 2, 30}
                },
                new[]
                {
                    new long[] {1, 2, 30},
                    new long[] {20, 20},
                    new long[] {1}
                },
                new RowMaxComparatorDescending())
                .SetDescription("Test descending. Reverse order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1},
                    null,
                    new long[] {20, 20},
                    null,
                    null,
                    new long[] {1, 2, 30}
                },
                new[]
                {
                    new long[] {1, 2, 30},
                    new long[] {20, 20},
                    new long[] {1},
                    null,
                    null,
                    null,
                },
                new RowMaxComparatorDescending())
                .SetDescription("Test with null rows descending.");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {1, 2, 30},
                    new long[] {20, 20},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {1, 2, 30},
                    new long[] {20, 20},
                    new long[] {1}
                },
                new RowMaxComparatorDescending())
                .SetDescription("Test descending. Right order of rows");
                yield return new TestCaseData
                    (new[]
                {
                    new long[] {20, 20},
                    new long[] {1, 2, 30},
                    new long[] {1}
                },
                new[]
                {
                    new long[] {1, 2, 30},
                    new long[] {20, 20},
                    new long[] {1}
                },
                new RowMaxComparatorDescending())
                .SetDescription("Test descending. Mixed order of rows");
            }
        }
        #endregion

        #region SortByRowMaxNegativeTestData
        public static IEnumerable<TestCaseData> SortByRowMaxNegativeTestData
        {
            get
            {
                yield return new TestCaseData
                        (null, typeof(ArgumentNullException),
                        new RowMaxComparatorAscending())
                    .SetDescription("Matrix is null");
            }
        }
        #endregion

        [Test, TestCaseSource(nameof(SortByRowMaxPositiveTestData))]
        public void SortByRowMax_JaggedArray_SortedJuggedArrayExpected(long[][] matrix,
            long[][] expectedMatrix, IComparer<long[]> comparer)
        {
            Sorter.BubbleSort(matrix, comparer);
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

        [Test, TestCaseSource(nameof(SortByRowMaxNegativeTestData))]
        public void SortByRowMax_JaggedArray_ExceptionExpected(long[][] matrix,
            Type expectedException, IComparer<long[]> comparator)
        {
            Assert.Throws(expectedException, 
                () => { Sorter.BubbleSort(matrix, comparator); });
        }

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
            }
        }
        #endregion

        [Test, TestCaseSource(nameof(SortByRowMinPositiveTestData))]
        public void SortByRowMin_JaggedArray_SortedJuggedArrayExpected(long[][] matrix,
            long[][] expectedMatrix, IComparer<long[]> comparer)
        {
            Sorter.BubbleSort(matrix, comparer);
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

        [Test, TestCaseSource(nameof(SortByRowMinNegativeTestData))]
        public void SortByRowMin_JaggedArray_ExceptionExpected(long[][] matrix,
            Type expectedException, IComparer<long[]> comparator)
        {
            Assert.Throws(expectedException, 
                () => {Sorter.BubbleSort(matrix, comparator); });
        }
    }
}
