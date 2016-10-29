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
        public long? Gcd_Arg1Arg2_GcdReturns(long x, long y)
        {
            return GcdMaster.Gcd(x, y);
        }
    }
}
