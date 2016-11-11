using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public class SorterTwin
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
            if (rowsComparator == null)
                throw new ArgumentNullException
                    ($"{nameof(rowsComparator)} parameter is null");
            BubbleSort(matrix, rowsComparator.Compare);
        }

        /// <summary>
        /// Sorts rows of the <paramref name="matrix"/> with using
        /// <paramref name="comparer"/>. 
        /// </summary>
        /// <param name="matrix">Matrix to sort</param>
        /// <param name="comparer"> delegate <see cref="Comparison{T}"/>
        ///  to compare rows of <paramref name="matrix"/>. </param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="matrix"/>
        /// or <paramref name="comparer"/> is null</exception>
        public static void BubbleSort
            (long[][] matrix, Comparison<long[]> comparer)
        {
            if (matrix == null)
                throw new ArgumentNullException
                    ($"{nameof(matrix)} parameter is null");
            if (comparer == null)
                throw new ArgumentNullException
                    ($"{nameof(comparer)} parameter is null");
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 1; j < matrix.Length - i; j++)
                {
                    if (comparer(matrix[j - 1], matrix[j]) > 0)
                    {
                        Swap(ref matrix[j - 1], ref matrix[j]);
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
