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
        public static long[][] SortByRowSum
            (this long[][] matrix, IComparer<long> rowSumsComparer = null)
        {
            BubbleSort(matrix, ((prev, value) => prev + value), rowSumsComparer);
            return matrix;
        }

        public static long[][] SortByRowMax
            (this long[][] matrix, IComparer<long> rowMaxComparer = null)
        {
            BubbleSort(matrix, Math.Max, rowMaxComparer);
            return matrix;
        }

        public static long[][] SortByRowMin
            (this long[][] matrix, IComparer<long> rowMaxComparer = null)
        {
            BubbleSort(matrix, Math.Min, rowMaxComparer);
            return matrix;
        }

        public class MaxComparer : IComparer<long>
        {
            public int Compare(long x, long y) => x.CompareTo(y);
        }

        public class MinComparer : IComparer<long>
        {
            public int Compare(long x, long y) => y.CompareTo(x);
        }

        private static void BubbleSort(long[][] matrix, 
            Func<long, long, long> aggregateFunc,
            IComparer<long> resultsComparer = null)
        {
            if (resultsComparer == null)
                resultsComparer = new MaxComparer();
            long[] rowsResults = new long[matrix.Length];
            for (int i = 0; i < rowsResults.Length; i++)
            {
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

