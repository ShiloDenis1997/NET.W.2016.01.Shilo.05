using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static Tuple<long?, TimeSpan> GcdEuclidean(long a, long b)
        {
            Stopwatch sw = Stopwatch.StartNew();  
            if (a == 0 && b == 0)
                return new Tuple<long?, TimeSpan>(null, sw.Elapsed);
            return new Tuple<long?, TimeSpan>
                (ComputeGcdEuclidian(Math.Abs(a), Math.Abs(b)), sw.Elapsed);
        }

        /// <summary>
        /// Computes GCD of three numbers
        /// </summary>
        /// <returns> null if all numbers equal to zero, GCD if not</returns>
        public static Tuple<long?, TimeSpan> GcdEuclidean(long a, long b, long c)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long ret = ComputeGcdEuclidian(ComputeGcdEuclidian(Math.Abs(a), Math.Abs(b)), Math.Abs(c));
            if (ret == 0)
                return new Tuple<long?, TimeSpan>(null, sw.Elapsed);
            return new Tuple<long?, TimeSpan>(ret, sw.Elapsed);
        }

        /// <summary>
        /// Computes GCD of variable amount of numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>null if all arguments are equal to zero</returns>
        /// <exception cref="ArgumentNullException">Throws when 
        /// <paramref name="numbers"/> is null</exception>
        /// <exception cref="ArgumentException">Throws when
        /// <paramref name="numbers"/> length is less than 2</exception>
        public static Tuple<long?, TimeSpan> GcdEuclidean(params long[] numbers)
        {
            Stopwatch sw = Stopwatch.StartNew();
            if (numbers == null)
                throw new ArgumentNullException($"{nameof(numbers)} is Nullable");
            if (numbers.Length < 2)
                throw new ArgumentException($"Number of parameters is less than 2");
            long ret = ComputeGcdEuclidian(Math.Abs(numbers[0]), Math.Abs(numbers[1]));
            for (int i = 2; i < numbers.Length; i++)
                ret = ComputeGcdEuclidian(ret, Math.Abs(numbers[i]));
            if (ret == 0)
                return new Tuple<long?, TimeSpan>(null, sw.Elapsed);
            return new Tuple<long?, TimeSpan>(ret, sw.Elapsed);
        }

        public static Tuple<long?, TimeSpan> GcdStein(long a, long b)
        {
            Stopwatch sw = Stopwatch.StartNew();
            if (a == 0 && b == 0)
                return new Tuple<long?, TimeSpan>(null, sw.Elapsed);
            return new Tuple<long?, TimeSpan>
                (ComputeGcdStein(Math.Abs(a), Math.Abs(b)), sw.Elapsed);
        }

        /// <summary>
        /// Computes gcd of two numbers. Uses Stein's algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>0 if both <paramref name="a"/> and <paramref name="b"/>
        /// are equal to zero, GCD if not</returns>
        private static long ComputeGcdStein(long a, long b)
        {
            int shift = 0;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            //shift is the greatest power of 2 dividing both numbers
            for (shift = 0; ((a | b) & 1) == 0; shift++)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;
            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                    Swap(ref a, ref b);
                b -= a;
            } while (b != 0);
            return a << shift;
        }

        /// <summary>
        /// Computes GCD of two numbers. Uses Euclidean algorithm
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>0 if both <paramref name="a"/> and <paramref name="b"/>
        /// are equal to zero, GCD if not</returns>
        private static long ComputeGcdEuclidian(long a, long b)
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

        private static void Swap(ref long a, ref long b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }
    }
}
