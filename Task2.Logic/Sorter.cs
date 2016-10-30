using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts the <paramref name="matrix"/> by sum of elements in row. 
        /// If <paramref name="rowSumsComparer"/> is not specified, rows will be
        /// sorted with <see cref="AscendingComparer"/>.
        /// </summary>
        /// <param name="matrix">Matrix to sort</param>
        /// <param name="rowSumsComparer">Specifies how to compare row's sums. If
        /// not specified, than <see cref="AscendingComparer"/> will be used</param>
        /// <returns>Reference to the sorted matrix which is the same to 
        /// <paramref name="matrix"/></returns>
        /// <exception cref="OverflowException">Throws when sum of elements in 
        /// one of the rows overflowing <see cref="long"/>/></exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="matrix"/>
        ///  or one of the rows of <paramref name="matrix"/>is null</exception>
        public static long[][] SortByRowSum
            (this long[][] matrix, IComparer<long> rowSumsComparer = null)
        {
            BubbleSort(matrix, (prev, value) => checked(prev + value),
                rowSumsComparer);
            return matrix;
        }

        /// <summary>
        /// Sorts the <paramref name="matrix"/> by maximum element in row. 
        /// If <paramref name="rowMaxComparer"/> is not specified, rows will be
        /// sorted with <see cref="AscendingComparer"/>.
        /// </summary>
        /// <param name="matrix">Matrix to sort</param>
        /// <param name="rowMaxComparer">Specifies how to compare row's maximums. If
        /// not specified, than <see cref="AscendingComparer"/> will be used</param>
        /// <returns>Reference to the sorted matrix which is the same to 
        /// <paramref name="matrix"/></returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="matrix"/>
        ///  or one of the rows of <paramref name="matrix"/>is null</exception>
        public static long[][] SortByRowMax
            (this long[][] matrix, IComparer<long> rowMaxComparer = null)
        {
            BubbleSort(matrix, Math.Max, rowMaxComparer);
            return matrix;
        }

        /// <summary>
        /// Sorts the <paramref name="matrix"/> by minimum element in row. 
        /// If <paramref name="rowMinComparer"/> is not specified, rows will be
        /// sorted with <see cref="AscendingComparer"/>.
        /// </summary>
        /// <param name="matrix">Matrix to sort</param>
        /// <param name="rowMinComparer">Specifies how to compare row's minimums. If
        /// not specified, than <see cref="AscendingComparer"/> will be used</param>
        /// <returns>Reference to the sorted matrix which is the same to 
        /// <paramref name="matrix"/></returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="matrix"/>
        ///  or one of the rows of <paramref name="matrix"/>is null</exception>
        public static long[][] SortByRowMin
            (this long[][] matrix, IComparer<long> rowMinComparer = null)
        {
            BubbleSort(matrix, Math.Min, rowMinComparer);
            return matrix;
        }

        public class AscendingComparer : IComparer<long>
        {
            public int Compare(long x, long y) => x.CompareTo(y);
        }

        public class DescendingComparer : IComparer<long>
        {
            public int Compare(long x, long y) => y.CompareTo(x);
        }

        /// <summary>
        /// Sorts the <paramref name="matrix"/> by result of
        /// <paramref name="aggregateFunc"/> applied to the row's elements. 
        /// If <paramref name="resultsComparer"/> is not specified, rows will be
        /// sorted with <see cref="AscendingComparer"/>.
        /// </summary>
        /// <param name="matrix">Matrix to sort</param>
        /// <param name="aggregateFunc">Aggregate values of the row</param>
        /// <param name="resultsComparer">Specifies how to compare row's sums. If
        /// not specified, than <see cref="AscendingComparer"/> will be used</param>
        /// <returns>Reference to the sorted matrix which is the same to 
        /// <paramref name="matrix"/></returns>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="matrix"/>
        /// or <paramref name="aggregateFunc"/> or one of the rows of 
        /// <paramref name="matrix"/>is null</exception>
        private static void BubbleSort(long[][] matrix, 
            Func<long, long, long> aggregateFunc,
            IComparer<long> resultsComparer = null)
        {
            if (matrix == null)
                throw new ArgumentNullException($"{nameof(matrix)} is null");
            if (aggregateFunc == null)
                throw new ArgumentNullException($"{nameof(aggregateFunc)} is null");
            if (resultsComparer == null)
                resultsComparer = new AscendingComparer();
            long[] rowsResults = new long[matrix.Length];
            for (int i = 0; i < rowsResults.Length; i++)
            {
                if (matrix[i] == null)
                    throw new ArgumentNullException
                        ($"Row number {i} of {nameof(matrix)} is null");
                rowsResults[i] = matrix[i][0];
                for (int j = 1; j < matrix[i].Length; j++)
                    rowsResults[i] = aggregateFunc(rowsResults[i], matrix[i][j]);
            }

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 1; j < matrix.Length - i; j++)
                {
                    if (resultsComparer
                        .Compare(rowsResults[j - 1], rowsResults[j]) > 0)
                    {
                        Swap(ref matrix[j - 1], ref matrix[j]);
                        Swap(ref rowsResults[j - 1], ref rowsResults[j]);
                    }
                }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
    }
}

