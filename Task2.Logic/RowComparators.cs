using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public class RowSumComparatorAscending : IRowsComparator
    {
        public int Compare(long[] row1, long[] row2)
        {
            if (row1 == null)
                throw new ArgumentNullException
                    ($"{nameof(row1)} parameter is null");
            if (row1.Length == 0)
                throw new ArgumentException($"{nameof(row1)} has no elements");
            if (row2 == null)
                throw new ArgumentNullException
                    ($"{nameof(row2)} parameter is null");
            if (row2.Length == 0)
                throw new ArgumentException($"{nameof(row2)} has no elements");
            long s1 = 0;
            for (int i = 0; i < row1.Length; i++)
                s1 = checked(s1 + row1[i]);
            long s2 = 0;
            for (int i = 0; i < row2.Length; i++)
                s2 = checked(s2 + row2[i]);
            return s1.CompareTo(s2);
        }
    }

    public class RowSumComparatorDescending : IRowsComparator
    {
        public int Compare(long[] row1, long[] row2)
        {
            if (row1 == null)
                throw new ArgumentNullException
                    ($"{nameof(row1)} parameter is null");
            if (row1.Length == 0)
                throw new ArgumentException($"{nameof(row1)} has no elements");
            if (row2 == null)
                throw new ArgumentNullException
                    ($"{nameof(row2)} parameter is null");
            if (row2.Length == 0)
                throw new ArgumentException($"{nameof(row2)} has no elements");
            
            long s1 = 0;
            foreach (long t in row1)
                s1 = checked(s1 + t);
            long s2 = 0;
            foreach (long t in row2)
                s2 = checked(s2 + t);
            return s2.CompareTo(s1);
        }
    }

    public class RowMaxComparatorAscending : IRowsComparator
    {
        public int Compare(long[] row1, long[] row2)
        {
            if (row1 == null)
                throw new ArgumentNullException
                    ($"{nameof(row1)} parameter is null");
            if (row1.Length == 0)
                throw new ArgumentException($"{nameof(row1)} has no elements");
            if (row2 == null)
                throw new ArgumentNullException
                    ($"{nameof(row2)} parameter is null");
            if (row2.Length == 0)
                throw new ArgumentException($"{nameof(row2)} has no elements");
            long max1 = row1[0];
            for (int i = 1; i < row1.Length; i++)
                max1 = Math.Max(max1, row1[i]);
            long max2 = row2[0];
            for (int i = 1; i < row2.Length; i++)
                max2 = Math.Max(max2, row2[i]);
            return max1.CompareTo(max2);
        }
    }

    public class RowMaxComparatorDescending : IRowsComparator
    {
        public int Compare(long[] row1, long[] row2)
        {
            if (row1 == null)
                throw new ArgumentNullException
                    ($"{nameof(row1)} parameter is null");
            if (row1.Length == 0)
                throw new ArgumentException($"{nameof(row1)} has no elements");
            if (row2 == null)
                throw new ArgumentNullException
                    ($"{nameof(row2)} parameter is null");
            if (row2.Length == 0)
                throw new ArgumentException($"{nameof(row2)} has no elements");
            long max1 = row1[0];
            for (int i = 1; i < row1.Length; i++)
                max1 = Math.Max(max1, row1[i]);
            long max2 = row2[0];
            for (int i = 1; i < row2.Length; i++)
                max2 = Math.Max(max2, row2[i]);
            return max2.CompareTo(max1);
        }
    }

    public class RowMinComparatorAscending : IRowsComparator
    {
        public int Compare(long[] row1, long[] row2)
        {
            if (row1 == null)
                throw new ArgumentNullException
                    ($"{nameof(row1)} parameter is null");
            if (row1.Length == 0)
                throw new ArgumentException($"{nameof(row1)} has no elements");
            if (row2 == null)
                throw new ArgumentNullException
                    ($"{nameof(row2)} parameter is null");
            if (row2.Length == 0)
                throw new ArgumentException($"{nameof(row2)} has no elements");
            long min1 = row1[0];
            for (int i = 1; i < row1.Length; i++)
                min1 = Math.Min(min1, row1[i]);
            long min2 = row2[0];
            for (int i = 1; i < row2.Length; i++)
                min2 = Math.Min(min2, row2[i]);
            return min1.CompareTo(min2);
        }
    }

    public class RowMinComparatorDescending : IRowsComparator
    {
        public int Compare(long[] row1, long[] row2)
        {
            if (row1 == null)
                throw new ArgumentNullException
                    ($"{nameof(row1)} parameter is null");
            if (row1.Length == 0)
                throw new ArgumentException($"{nameof(row1)} has no elements");
            if (row2 == null)
                throw new ArgumentNullException
                    ($"{nameof(row2)} parameter is null");
            if (row2.Length == 0)
                throw new ArgumentException($"{nameof(row2)} has no elements");
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
