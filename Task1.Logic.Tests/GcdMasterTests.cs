using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Task1.Logic.Tests
{
    [TestFixture]
    public class GcdMasterTests
    {
        [TestCase(0, 0, ExpectedResult = null,
            Description = "Two zeroes haven't gcd")]
        [TestCase(10, 30, ExpectedResult = 10,
            Description = "First number is gcd")]
        [TestCase(28, 7, ExpectedResult = 7,
            Description = "Second number is gcd")]
        [TestCase(0, 25, ExpectedResult = 25,
            Description = "First number is zero")]
        [TestCase(25, 0, ExpectedResult = 25,
            Description = "Second number is zero")]
        [TestCase(54, 48, ExpectedResult = 6,
            Description = "First nubmer > second.")]
        [TestCase(48, 54, ExpectedResult = 6,
            Description = "Second number > first")]
        [TestCase(36, 11, ExpectedResult = 1,
            Description = "First > second, gcd = 1")]
        [TestCase(11, 36, ExpectedResult = 1,
            Description = "Second > first, gcd = 1")]
        [TestCase(-48, -16, ExpectedResult = 16,
            Description = "Two negative numbers, gcd = abs(second)")]
        [TestCase(-16, -48, ExpectedResult = 16,
            Description = "Two negative nubmers, gcd = abs(first)")]
        [TestCase(-48, -36, ExpectedResult = 12,
            Description = "Two negative numbers. abs(first) > abs(second)")]
        [TestCase(-48, 36, ExpectedResult = 12,
            Description = "First < 0, second > 0")]
        [TestCase(36, -48, ExpectedResult = 12,
            Description = "First > 0, second < 0")]
        [Test]
        public long? Gcd_Arg1Arg2_GcdReturns(long a, long b)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Tuple<long?, TimeSpan> actual = GcdMaster.GcdEuclidean(a, b);
            sw.Stop();
            Assert.LessOrEqual
                (actual.Item2, sw.Elapsed, "Time was measured bad");
            return actual.Item1;
        }

        [TestCase(0, 0, 0, ExpectedResult = null,
            Description = "Three zeroes haven't gcd")]
        [TestCase(0, 0, 25, ExpectedResult = 25,
            Description = "First and second number are zeroes")]
        [TestCase(25, 0, 0, ExpectedResult = 25,
            Description = "Second and third number are zeroes")]
        [TestCase(0, 25, 0, ExpectedResult = 25,
            Description = "First and third number are zeroes")]
        [TestCase(10, 30, 60, ExpectedResult = 10,
            Description = "First number is gcd")]
        [TestCase(56, 28, 84, ExpectedResult = 28,
            Description = "Second number is gcd")]
        [TestCase(56, 84, 28, ExpectedResult = 28,
            Description = "Third number is gcd")]
        [TestCase(54, 48, 36, ExpectedResult = 6,
            Description = "First nubmer > second > third.")]
        [TestCase(36, 48, 54, ExpectedResult = 6,
            Description = "First < second < third")]
        [TestCase(36, 11, 22, ExpectedResult = 1,
            Description = "second is minimum, gcd = 1")]
        [TestCase(11, 36, 22, ExpectedResult = 1,
            Description = "First is minimum, gcd = 1")]
        [TestCase(-48, -16, -32, ExpectedResult = 16,
            Description = "Three negative numbers, gcd = abs(second)")]
        [TestCase(-16, -32, -48, ExpectedResult = 16,
            Description = "Three negative nubmers, gcd = abs(first)")]
        [TestCase(-32, -48, -16, ExpectedResult = 16,
            Description = "Three negative nubmers, gcd = abs(third)")]
        [TestCase(-48, -36, -24, ExpectedResult = 12,
            Description = "Two negative numbers. abs(first) > abs(second) > abs(third)")]
        [TestCase(-48, 36, 24, ExpectedResult = 12,
            Description = "First < 0, second > 0, third > 0")]
        [TestCase(36, -48, 24, ExpectedResult = 12,
            Description = "First > 0, second < 0, third > 0")]
        [TestCase(36, 48, -24, ExpectedResult = 12,
            Description = "First > 0, second < 0, third < 0")]
        [Test]
        public long? Gcd_Arg1Arg2Arg3_GcdReturns(long a, long b, long c)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Tuple<long?, TimeSpan> actual = GcdMaster.GcdEuclidean(a, b, c);
            sw.Stop();
            Assert.LessOrEqual
                (actual.Item2, sw.Elapsed, "Time was measured bad");
            return actual.Item1;
        }

        [TestCase(new long[] {0, 0, 0, 0}, ExpectedResult = null,
            Description = "All arguments are equal to zero")]
        [TestCase(new long[] {0, 0, 0, 25}, ExpectedResult = 25,
            Description = "Only last number is non-zero")]
        [TestCase(new long[] {25, 0, 0, 0}, ExpectedResult = 25,
            Description = "Only first number is non-zero")]
        [TestCase(new long[] {0, 25, 0, 0}, ExpectedResult = 25,
            Description = "Only one of inner numbers is non-zero")]
        [TestCase(new long[] {10, 30, 60, 70}, ExpectedResult = 10,
            Description = "First number is gcd")]
        [TestCase(new long[] {56, 28, 84, 56}, ExpectedResult = 28,
            Description = "One of inner numbers is gcd")]
        [TestCase(new long[] {56, 84, 84, 28}, ExpectedResult = 28,
            Description = "Last number is gcd")]
        [TestCase(new long[] {54, 48, 36, 48}, ExpectedResult = 6,
            Description = "There are no elements equal to gcd")]
        [TestCase(new long[] {36, 11, 22, 12, 25}, ExpectedResult = 1,
            Description = "gcd = 1")]
        [TestCase(new long[] {-48, -16, -32, -64}, ExpectedResult = 16,
            Description = "Array with negative numbers. gcd = abs(second)")]
        [TestCase(new long[] {-16, 32, -48, 64}, ExpectedResult = 16,
            Description = "Array with positive and negative numbers. gcd = abs(first)")]
        [TestCase(new long[] {-48, -36, -24, 60}, ExpectedResult = 12,
            Description = "Array with positive and negative nubmers. No one element " +
                          "is equal to gcd")]
        [TestCase(new long[] {24, 18, 12, 20, 48, 1022}, ExpectedResult = 2,
            Description = "Long array test")]
        [TestCase(new long[] {-120, 20, 240, -180, -55}, ExpectedResult = 5,
            Description = "Negative long array test")]
        [TestCase(new long[] { -120, 20, 240}, ExpectedResult = 20,
            Description = "Array with three arguments")]
        [TestCase(new long[] { -120, 20 }, ExpectedResult = 20,
            Description = "Array with two arguments")]
        [Test]
        public long? Gcd_Args_GcdReturns(long[] numbers)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Tuple<long?, TimeSpan> actual = GcdMaster.GcdEuclidean(numbers);
            sw.Stop();
            Assert.LessOrEqual
                (actual.Item2, sw.Elapsed, "Time was measured bad");
            return actual.Item1;
        }

        [TestCase(null, typeof(ArgumentNullException),
            Description = "null array test")]
        [TestCase(new long[] { }, typeof(ArgumentException),
            Description = "empty array test")]
        [TestCase(new long[] { 2 }, typeof(ArgumentException),
            Description = "array with one element test")]
        [Test]
        public void Gcd_Args_ExceptionExpected
            (long[] numbers, Type expectedExceptionType)
        {
            Assert.Throws(expectedExceptionType, 
                () => { GcdMaster.GcdEuclidean(numbers); });
        }

        [TestCase(0, 0, ExpectedResult = null,
            Description = "Two zeroes haven't gcd")]
        [TestCase(10, 30, ExpectedResult = 10,
            Description = "First number is gcd")]
        [TestCase(28, 7, ExpectedResult = 7,
            Description = "Second number is gcd")]
        [TestCase(0, 25, ExpectedResult = 25,
            Description = "First number is zero")]
        [TestCase(25, 0, ExpectedResult = 25,
            Description = "Second number is zero")]
        [TestCase(54, 48, ExpectedResult = 6,
            Description = "First nubmer > second.")]
        [TestCase(48, 54, ExpectedResult = 6,
            Description = "Second number > first")]
        [TestCase(36, 11, ExpectedResult = 1,
            Description = "First > second, gcd = 1")]
        [TestCase(11, 36, ExpectedResult = 1,
            Description = "Second > first, gcd = 1")]
        [TestCase(-48, -16, ExpectedResult = 16,
            Description = "Two negative numbers, gcd = abs(second)")]
        [TestCase(-16, -48, ExpectedResult = 16,
            Description = "Two negative nubmers, gcd = abs(first)")]
        [TestCase(-48, -36, ExpectedResult = 12,
            Description = "Two negative numbers. abs(first) > abs(second)")]
        [TestCase(-48, 36, ExpectedResult = 12,
            Description = "First < 0, second > 0")]
        [TestCase(36, -48, ExpectedResult = 12,
            Description = "First > 0, second < 0")]
        [Test]
        public long? GcdStein_Arg1Arg2_ResultExpected(long a, long b)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Tuple<long?, TimeSpan> actual = GcdMaster.GcdStein(a, b);
            sw.Stop();
            Assert.LessOrEqual
                (actual.Item2, sw.Elapsed, "Time was measured bad");
            return actual.Item1;
        }
    }
}
