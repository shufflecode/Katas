
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
        public long FixedTests(long n)
        {
            return NextSmallerKata.NextSmaller(n);
        }
    }
}