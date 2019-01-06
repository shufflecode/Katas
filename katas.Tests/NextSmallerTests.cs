
using katas;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class NextSmallerTests
    {
        [TestCase(21, ExpectedResult = 12)]
        [TestCase(907, ExpectedResult = 790)]
        [TestCase(531, ExpectedResult = 513)]
        [TestCase(1027, ExpectedResult = -1)]
        [TestCase(441, ExpectedResult = 414)]
        [TestCase(123456784987654321, ExpectedResult = 123456785123446789)]
        public long FixedTests(long n)
        {
            return NextSmallerKata.NextSmaller(n);
        }
    }
}