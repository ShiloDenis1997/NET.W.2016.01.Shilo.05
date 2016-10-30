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
                    new long[] {1, 2},
                    new long[] {1, 2, 3}
                },
                new[]
                {
                    new long[] {1},
                    new long[] {1, 2},
                    new long[] {1, 2, 3}
                },
                new Sorter.AscendingComparer())
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
                new Sorter.AscendingComparer())
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
                new Sorter.AscendingComparer())
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
                new Sorter.DescendingComparer())
                .SetDescription("Test descending. Reverse order of rows");
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
                new Sorter.DescendingComparer())
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
                new Sorter.DescendingComparer())
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
                        (null, typeof(ArgumentNullException))
                    .SetDescription("Matrix is null");
                yield return new TestCaseData
                    (new[]
                    {
                        new long[] {1},
                        null,
                        new long[] {1, 2, 3}
                    }, typeof(ArgumentNullException))
                    .SetDescription("One of the rows is null");
                yield return new TestCaseData
                    (new[]
                {
                    new [] {long.MaxValue, long.MaxValue},
                    new long[] {1, 2, 3},
                }, typeof(OverflowException))
                .SetDescription("Sum of elements in the first row is" +
                                $"greater than {long.MaxValue}");
                yield return new TestCaseData
                    (new[]
                {
                    new [] {long.MinValue, long.MinValue},
                    new long[] {1, 2, 3},
                }, typeof(OverflowException))
                .SetDescription("Sum of elements in the first row is" +
                                $"less than {long.MinValue}");
            }
        } 
        #endregion

        [Test, TestCaseSource(nameof(SortByRowSumPositiveTestData))]
        public void SortByRowSum_JaggedArray_SortedJuggedArrayExpected(long[][] matrix,
            long[][] expectedMatrix, IComparer<long> comparer)
        {
            long[][] actual = matrix.SortByRowSum(comparer);
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

        [Test, TestCaseSource(nameof(SortByRowSumNegativeTestData))]
        public void SortByRowSum_JaggedArray_ExceptionExpected(long[][] matrix,
            Type expectedException)
        {
            Assert.Throws(expectedException, () => { matrix.SortByRowSum(); });
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
                new Sorter.AscendingComparer())
                .SetDescription("Test ascending. Mix order of rows");
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
                new Sorter.AscendingComparer())
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
                new Sorter.AscendingComparer())
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
                new Sorter.DescendingComparer())
                .SetDescription("Test descending. Reverse order of rows");
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
                new Sorter.DescendingComparer())
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
                new Sorter.DescendingComparer())
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
                        (null, typeof(ArgumentNullException))
                    .SetDescription("Matrix is null");
                yield return new TestCaseData
                    (new[]
                    {
                        new long[] {1},
                        null,
                        new long[] {1, 2, 3}
                    }, typeof(ArgumentNullException))
                    .SetDescription("One of the rows is null");
            }
        }
        #endregion

        [Test, TestCaseSource(nameof(SortByRowMaxPositiveTestData))]
        public void SortByRowMax_JaggedArray_SortedJuggedArrayExpected(long[][] matrix,
            long[][] expectedMatrix, IComparer<long> comparer)
        {
            long[][] actual = matrix.SortByRowMax(comparer);
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

        [Test, TestCaseSource(nameof(SortByRowMaxNegativeTestData))]
        public void SortByRowMax_JaggedArray_ExceptionExpected(long[][] matrix,
            Type expectedException)
        {
            Assert.Throws(expectedException, () => { matrix.SortByRowMax(); });
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
                    new long[] {1, 12, 13},
                    new long[] {10, 10}
                },
                new[]
                {
                    new long[] {1, 12, 13},
                    new long[] {10, 10},
                    new long[] {15}
                },
                new Sorter.AscendingComparer())
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
                new Sorter.AscendingComparer())
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
                new Sorter.AscendingComparer())
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
                new Sorter.DescendingComparer())
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
                new Sorter.DescendingComparer())
                .SetDescription("Test descending. Right order of rows");
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
                new Sorter.DescendingComparer())
                .SetDescription("Test descending. Mixed order of rows");
            }
        }
        #endregion

        #region SortByRowMaxNegativeTestData
        public static IEnumerable<TestCaseData> SortByRowMinNegativeTestData
        {
            get
            {
                yield return new TestCaseData
                        (null, typeof(ArgumentNullException))
                    .SetDescription("Matrix is null");
                yield return new TestCaseData
                    (new[]
                    {
                        new long[] {1},
                        null,
                        new long[] {1, 2, 3}
                    }, typeof(ArgumentNullException))
                    .SetDescription("One of the rows is null");
            }
        }
        #endregion

        [Test, TestCaseSource(nameof(SortByRowMinPositiveTestData))]
        public void SortByRowMin_JaggedArray_SortedJuggedArrayExpected(long[][] matrix,
            long[][] expectedMatrix, IComparer<long> comparer)
        {
            long[][] actual = matrix.SortByRowMin(comparer);
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

        [Test, TestCaseSource(nameof(SortByRowMinNegativeTestData))]
        public void SortByRowMin_JaggedArray_ExceptionExpected(long[][] matrix,
            Type expectedException)
        {
            Assert.Throws(expectedException, () => { matrix.SortByRowMin(); });
        }
    }
}
