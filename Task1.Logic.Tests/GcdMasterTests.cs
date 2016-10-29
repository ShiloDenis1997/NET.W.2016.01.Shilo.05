using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return GcdMaster.Gcd(a, b);
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
            return GcdMaster.Gcd(a, b, c);
        }
    }
}
