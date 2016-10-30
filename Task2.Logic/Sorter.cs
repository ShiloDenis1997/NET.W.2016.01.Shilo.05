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
        public static long[][] Sort(this long[][] matrix)
        {
            long[] rowResults = new long[matrix.Length];
            for (int i = 0; i < rowResults.Length; i++)
            {
                rowResults[i] = Sum(0, matrix[0][0]);
                for (int j = 1; j < matrix[i].Length; j++)
                    rowResults[i] = Sum(rowResults[i], matrix[i][j]);
            }

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 1; j < matrix.Length - i; j++)
                {
                    if (rowResults[j - 1] > rowResults[j])
                    {
                        Swap(ref matrix[j - 1], ref matrix[j]);
                        Swap(ref rowResults[j - 1], ref rowResults[j]);
                    }
                }
            return matrix;
        }

        private static long Max(long previosResult, long value)
        {
            return Math.Max(previosResult, value);
        }

        private static long Min(long previosResult, long value)
        {
            return Math.Min(previosResult, value);
        }

        private static long Sum(long previosResult, long value)
        {
            return checked(previosResult + value);
        }

        private class MaxComparer : IComparer <long>
        {
            public int Compare(long x, long y)
            {
                return x.CompareTo(y);
            }
        }

        //private static void SwapRows(ref long[] xRow, ref long[] yRow)
        //{
        //    long[] tempRow = xRow;
        //    xRow = yRow;
        //    yRow = tempRow;
        //}

        private static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

    }
}

