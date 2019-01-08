
using katas;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class NextSmallerTests
    {
        [TestCase(21, ExpectedResult = 12)]
        [TestCase(9, ExpectedResult = -1)]
        [TestCase(111, ExpectedResult = -1)]
        [TestCase(135, ExpectedResult = -1)]
        [TestCase(907, ExpectedResult = 790)]
        [TestCase(531, ExpectedResult = 513)]
        [TestCase(1027, ExpectedResult = -1)]
        [TestCase(441, ExpectedResult = 414)]
        [TestCase(123456798, ExpectedResult = 123456789)]
        public long FixedTests(long n)
        {
            return Kata.NextSmaller(n);
        }
    }
}