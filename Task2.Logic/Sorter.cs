using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2.Logic
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts rows of the <paramref name="matrix"/> with using
        /// <paramref name="rowsComparator"/>. 
        /// </summary>
        /// <param name="matrix">Matrix to sort</param>
        /// <param name="rowsComparator">Implementation 
        /// of <see cref="IComparer{T}"/> to compare rows 
        /// of <paramref name="matrix"/></param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="matrix"/>
        /// or <paramref name="rowsComparator"/> is null</exception>
        public static void BubbleSort(long[][] matrix,
            IComparer<long[]> rowsComparator)
        {
            if (matrix == null)
                throw new ArgumentNullException
                    ($"{nameof(matrix)} parameter is null");
            if (rowsComparator == null)
                throw new ArgumentNullException
                    ($"{nameof(rowsComparator)} parameter is null");
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 1; j < matrix.Length - i; j++)
                {
                    if (rowsComparator.Compare(matrix[j - 1], matrix[j]) > 0)
                    {
                        Swap(ref matrix[j - 1], ref matrix[j]);
                    }
                }
        }

        public static void BubbleSort
            (long[][] matrix, Func<long[], long[], int> comparer)
        {
            BubbleSort(matrix, new DelegateToInterfaceHelper<long[]>(comparer));
        }

        /// <summary>
        /// Wraps delegate with <see cref="IComparer{T}"/> interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class DelegateToInterfaceHelper <T>: IComparer<T>
        {
            private readonly Func<T, T, int> comparer;

            public DelegateToInterfaceHelper(Func<T, T, int> comparer)
            {
                this.comparer = comparer;
            }

            public int Compare(T x, T y)
            {
                return comparer(x, y);
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

