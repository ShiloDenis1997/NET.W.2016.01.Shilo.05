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
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 1; j < matrix.Length - i; j++)
                {
                    long sumjm1 = 0;
                    long sumj = 0;
                    for (int j1 = 0; j1 < matrix[j - 1].Length; j1++)
                    {
                        sumjm1 += matrix[j][j1];
                        sumj += matrix[j][j1];
                    }
                    if (sumjm1 > sumj)
                        SwapRows(ref matrix[j - 1], ref matrix[j]);
                }
            return matrix;
        }

        private static void SwapRows(ref long[] xRow, ref long[] yRow)
        {
            long[] tempRow = xRow;
            xRow = yRow;
            yRow = tempRow;
        }

    }
}

