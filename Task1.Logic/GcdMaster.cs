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
        /// Computes GCD of two numbers. Uses Euclidean algorithm
        /// </summary>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if both a and b
        /// are equal to zero or gcd if not. 
        /// Item2 is an elapsed time during which method works
        /// </returns>
        public static Tuple<long, TimeSpan> GcdEuclideanTime(this long a, long b)
        {
            return GcdPatternTime(ComputeGcdEuclidian, a, b);
        }

        /// <summary>
        /// Computes GCD of three numbers. Uses Euclidean algorithm
        /// </summary>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if all arguments
        /// are equal to zero or gcd if not. 
        /// Item2 is an elapsed time during which method works</returns>
        public static Tuple<long, TimeSpan> GcdEuclideanTime(this long a, long b, long c)
        {
            return GcdPatternTime(ComputeGcdEuclidian, a, b, c);
        }

        /// <summary>
        /// Computes GCD of variable amount of numbers. Uses Euclidean algorithm
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if all arguments
        /// are equal to zero or gcd if not. 
        /// Item2 is an elapsed time during which method works</returns>
        /// <exception cref="ArgumentNullException">Throws when 
        /// <paramref name="numbers"/> is null</exception>
        /// <exception cref="ArgumentException">Throws when
        /// <paramref name="numbers"/> length is less than 2</exception>
        public static Tuple<long, TimeSpan> GcdEuclideanTime(params long[] numbers)
        {
            return GcdPatternTime(ComputeGcdEuclidian, numbers);
        }

        /// <summary>
        /// Computes GCD of two numbers. Uses Stein's algorithm
        /// </summary>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if all 
        /// arguments are equal to zero or gcd if not.
        /// Item2 is an elapsed time during which method works</returns>
        public static Tuple<long, TimeSpan> GcdSteinTime(this long a, long b)
        {
            return GcdPatternTime(ComputeGcdStein, a, b);
        }

        /// <summary>
        /// Computes GCD of three numbers. Uses Stein's algorithm
        /// </summary>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if all 
        /// arguments are equal to zero or gcd if not.
        /// Item2 is an elapsed time during which method works </returns>
        public static Tuple<long, TimeSpan> GcdSteinTime
            (this long a, long b, long c)
        {
            return GcdPatternTime(ComputeGcdStein, a, b, c);
        }

        /// <summary>
        /// Computes GCD of variable amount of numbers. Uses Stein's algorithm
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if all 
        /// arguments are equal to zero or gcd if not.
        /// Item2 is an elapsed time during which method works </returns>
        /// <exception cref="ArgumentNullException">Throws when 
        /// <paramref name="numbers"/> is null</exception>
        /// <exception cref="ArgumentException">Throws when
        /// <paramref name="numbers"/> length is less than 2</exception>
        public static Tuple<long, TimeSpan> GcdSteinTime(params long[] numbers)
        {
            return GcdPatternTime(ComputeGcdStein, numbers);
        }

        private static long GcdPattern
        (Func<long, long, long> gcdFunc, long a,
            long b)
        {
            return gcdFunc(Math.Abs(a), Math.Abs(b));
        }

        private static long GcdPattern(Func<long, long, long> gcdFunc, long a,
            long b, long c)
        {
            return gcdFunc(gcdFunc(Math.Abs(a), Math.Abs(b)), Math.Abs(c));
        }

        /// <summary>
        /// Implements a strategy of computing GCD of 2 arguments.
        /// </summary>
        /// <param name="gcdFunc">Function that computes GCD of 2 arguments
        /// </param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if all 
        /// arguments are equal to zero or gcd if not.
        /// Item2 is an elapsed time during which method works </returns>
        private static Tuple<long, TimeSpan> GcdPatternTime
            (Func<long, long, long> gcdFunc, long a,
            long b)
        {
            Stopwatch sw = Stopwatch.StartNew();
            return new Tuple<long, TimeSpan>(GcdPattern(gcdFunc, a, b), sw.Elapsed);
        }

        /// <summary>
        /// Implements a strategy of computing GCD of 3 arguments.
        /// </summary>
        /// <param name="gcdFunc">Function that computes GCD of 2 arguments
        /// </param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if all 
        /// arguments are equal to zero or gcd if not.
        /// Item2 is an elapsed time during which method works </returns>
        private static Tuple<long, TimeSpan> GcdPatternTime
            (Func<long, long, long> gcdFunc, long a, long b, long c)
        {
            Stopwatch sw = Stopwatch.StartNew();
            return new Tuple<long, TimeSpan>(GcdPattern(gcdFunc, a, b, c), sw.Elapsed);
        }

        private static long GcdPattern
            (Func<long, long, long> gcdFunc, params long[] numbers)
        {
            Stopwatch sw = Stopwatch.StartNew();
            if (numbers == null)
                throw new ArgumentNullException($"{nameof(numbers)} is Nullable");
            if (numbers.Length < 2)
                throw new ArgumentException($"Number of parameters is less than 2");
            long ret = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                ret = gcdFunc(ret, Math.Abs(numbers[i]));
            return ret;
        }

        /// <summary>
        /// Implements a strategy of computing GCD of 
        /// variable number of arguments.
        /// </summary>
        /// <param name="gcdFunc">Function that computes GCD of 2 arguments
        /// </param>
        /// <param name="numbers"></param>
        /// <returns>Tuple(Item1, Item2) where Item1 == null if all 
        /// arguments are equal to zero or gcd if not.
        /// Item2 is an elapsed time during which method works </returns>
        /// <exception cref="ArgumentNullException">Throws when 
        /// <paramref name="numbers"/> is null</exception>
        /// <exception cref="ArgumentException">Throws when
        /// <paramref name="numbers"/> length is less than 2</exception>
        private static Tuple<long, TimeSpan> GcdPatternTime
            (Func<long, long, long> gcdFunc, params long[] numbers)
        {
            Stopwatch sw = Stopwatch.StartNew();
            return new Tuple<long, TimeSpan>(GcdPattern(gcdFunc, numbers), sw.Elapsed);
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
