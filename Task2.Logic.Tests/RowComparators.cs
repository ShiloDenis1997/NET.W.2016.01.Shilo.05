using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic.Tests
{
    /// <summary>
    /// Compares two sz-arrays by row's sums in ascending order
    /// </summary>
    public class RowSumComparatorAscending : IComparer<long[]>
    {
        /// <summary>
        /// Compares two sz-arrays by sum of elements. Null array is 
        /// always the greatest
        /// </summary>
        /// <param name="row1">First array</param>
        /// <param name="row2">Second array</param>
        /// <returns>Value greater than 0 if sum of elements in
        /// <paramref name="row1"/> is greater than sum of elements in
        /// <paramref name="row2"/>. Zero if sums are equals. Less than
        /// 0 if sum of elements in <paramref name="row1"/> is less than
        /// sum of elements in <paramref name="row2"/></returns>
        public int Compare(long[] row1, long[] row2)
        {
            if (ReferenceEquals(row1, row2))
                return 0;
            if (row1 == null)
                return 1;
            if (row2 == null)
                return -1;
            long s1 = 0;
            foreach (long t in row1)
                s1 = checked(s1 + t);
            long s2 = 0;
            foreach (long t in row2)
                s2 = checked(s2 + t);
            return s1.CompareTo(s2);
        }
    }

    /// <summary>
    /// Compares two sz-arrays by row's sums in ascending order
    /// </summary>
    public class RowSumComparatorDescending : IComparer<long[]>
    {
        /// <summary>
        /// Compares two sz-arrays by sum of elements. Null array is 
        /// always the greatest
        /// </summary>
        /// <param name="row1">First array</param>
        /// <param name="row2">Second array</param>
        /// <returns>Value greater than 0 if sum of elements in
        /// <paramref name="row2"/> is greater than sum of elements in
        /// <paramref name="row1"/>. Zero if sums are equals. Less than
        /// 0 if sum of elements in <paramref name="row2"/> is less than
        /// sum of elements in <paramref name="row1"/></returns>
        public int Compare(long[] row1, long[] row2)
        {
            if (ReferenceEquals(row1, row2))
                return 0;
            if (row1 == null)
                return 1;
            if (row2 == null)
                return -1;

            long s1 = 0;
            foreach (long t in row1)
                s1 = checked(s1 + t);
            long s2 = 0;
            foreach (long t in row2)
                s2 = checked(s2 + t);
            return s2.CompareTo(s1);
        }
    }

    /// <summary>
    /// Compares two sz-arrays by row's maximums in ascending order
    /// </summary>
    public class RowMaxComparatorAscending : IComparer<long[]>
    {
        /// <summary>
        /// Compares two sz-arrays by maximum element. Null array is 
        /// always the greatest
        /// </summary>
        /// <param name="row1">First array</param>
        /// <param name="row2">Second array</param>
        /// <returns>Value greater than 0 if maximum element in
        /// <paramref name="row1"/> is greater than maximum element in
        /// <paramref name="row2"/>. Zero if sums are equals. Less than
        /// 0 if maximum element in <paramref name="row1"/> is less than
        /// maximum element in <paramref name="row2"/></returns>
        public int Compare(long[] row1, long[] row2)
        {
            if (ReferenceEquals(row1, row2))
                return 0;
            if (row1 == null)
                return 1;
            if (row2 == null)
                return -1;

            long max1 = row1[0];
            for (int i = 1; i < row1.Length; i++)
                max1 = Math.Max(max1, row1[i]);
            long max2 = row2[0];
            for (int i = 1; i < row2.Length; i++)
                max2 = Math.Max(max2, row2[i]);
            return max1.CompareTo(max2);
        }
    }

    /// <summary>
    /// Compares two sz-arrays by row's maximums in descending order
    /// </summary>
    public class RowMaxComparatorDescending : IComparer<long[]>
    {
        /// <summary>
        /// Compares two sz-arrays by maximum element. Null array is 
        /// always the greatest
        /// </summary>
        /// <param name="row1">First array</param>
        /// <param name="row2">Second array</param>
        /// <returns>Value greater than 0 if maximum element in
        /// <paramref name="row2"/> is greater than maximum element in
        /// <paramref name="row1"/>. Zero if sums are equals. Less than
        /// 0 if maximum element in <paramref name="row2"/> is less than
        /// maximum element in <paramref name="row1"/></returns>
        public int Compare(long[] row1, long[] row2)
        {
            if (ReferenceEquals(row1, row2))
                return 0;
            if (row1 == null)
                return 1;
            if (row2 == null)
                return -1;

            long max1 = row1[0];
            for (int i = 1; i < row1.Length; i++)
                max1 = Math.Max(max1, row1[i]);
            long max2 = row2[0];
            for (int i = 1; i < row2.Length; i++)
                max2 = Math.Max(max2, row2[i]);
            return max2.CompareTo(max1);
        }
    }

    /// <summary>
    /// Compares two sz-arrays by row's minimums in ascending order
    /// </summary>
    public class RowMinComparatorAscending : IComparer<long[]>
    {
        /// <summary>
        /// Compares two sz-arrays by maximum element. Null array is 
        /// always the greatest
        /// </summary>
        /// <param name="row1">First array</param>
        /// <param name="row2">Second array</param>
        /// <returns>Value greater than 0 if minimum element in
        /// <paramref name="row1"/> is greater than minimum element in
        /// <paramref name="row2"/>. Zero if sums are equals. Less than
        /// 0 if minimum element in <paramref name="row1"/> is less than
        /// minimum element in <paramref name="row2"/></returns>
        public int Compare(long[] row1, long[] row2)
        {
            if (ReferenceEquals(row1, row2))
                return 0;
            if (row1 == null)
                return 1;
            if (row2 == null)
                return -1;

            long min1 = row1[0];
            for (int i = 1; i < row1.Length; i++)
                min1 = Math.Min(min1, row1[i]);
            long min2 = row2[0];
            for (int i = 1; i < row2.Length; i++)
                min2 = Math.Min(min2, row2[i]);
            return min1.CompareTo(min2);
        }
    }

    /// <summary>
    /// Compares two sz-arrays by row's minimums in descending order
    /// </summary>
    public class RowMinComparatorDescending : IComparer<long[]>
    {
        /// <summary>
        /// Compares two sz-arrays by maximum element. Null array is 
        /// always the greatest
        /// </summary>
        /// <param name="row1">First array</param>
        /// <param name="row2">Second array</param>
        /// <returns>Value greater than 0 if minimum element in
        /// <paramref name="row2"/> is greater than minimum element in
        /// <paramref name="row1"/>. Zero if sums are equals. Less than
        /// 0 if minimum element in <paramref name="row2"/> is less than
        /// minimum element in <paramref name="row1"/></returns>
        public int Compare(long[] row1, long[] row2)
        {
            if (ReferenceEquals(row1, row2))
                return 0;
            if (row1 == null)
                return 1;
            if (row2 == null)
                return -1;

            long min1 = row1[0];
            for (int i = 1; i < row1.Length; i++)
                min1 = Math.Min(min1, row1[i]);
            long min2 = row2[0];
            for (int i = 1; i < row2.Length; i++)
                min2 = Math.Min(min2, row2[i]);
            return min2.CompareTo(min1);
        }
    }
}
