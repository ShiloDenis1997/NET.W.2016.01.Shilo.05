using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic
{
    public static class GcdMaster
    {
        /// <summary>
        /// Computes GCD of two numbers
        /// </summary>
        /// <returns>null if both numbers are zeroes, GCD if not</returns>
        public static long? Gcd(long a, long b)
        {
            if (a == 0 && b == 0)
                return null;
            return ComputeGcd(Math.Abs(a), Math.Abs(b));
        }

        /// <summary>
        /// Computes GCD of three numbers
        /// </summary>
        /// <returns> null if all numbers equal to zero, GCD if not</returns>
        public static long? Gcd(long a, long b, long c)
        {
            long ret = ComputeGcd(ComputeGcd(Math.Abs(a), Math.Abs(b)), Math.Abs(c));
            if (ret == 0)
                return null;
            return ret;
        }

        private static long ComputeGcd(long a, long b)
        {
            if (a == 0)
                return b;
            while (a != 0 && b != 0)
            {
                if (a < b)
                {
                    b %= a;
                }
                else
                {
                    a %= b;
                }
            }
            if (a == 0)
                return b;
            return a;
        }
    }
}
